#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediaInfo.TestFilesGenerator.Models;

namespace MediaInfo.TestFilesGenerator;

/// <summary>
/// Pre-generates all <see cref="AudioParameters"/> with a seeded RNG for
/// reproducibility, then runs FFmpeg in parallel to produce the MKA files.
/// </summary>
/// <param name="ffmpegPath">The path to the FFmpeg executable.</param>
/// <param name="outputDir">The directory to write generated files to.</param>
/// <param name="seed">The seed for the random parameter generator.</param>
/// <param name="parallelism">The number of parallel FFmpeg processes to run.</param>
internal sealed class FileGenerator(string outputDir, string ffmpegPath, int seed, int parallelism)
{
  private readonly string _outputDir = outputDir;
  private readonly string _ffmpegPath = ffmpegPath;
  private readonly ParameterGenerator _paramGen = new ParameterGenerator(seed);
  private readonly FfmpegCommandBuilder _cmdBuilder = new FfmpegCommandBuilder();
  private readonly int _parallelism = parallelism;

  private int _succeeded;
  private int _failed;

  public async Task Generate(int count)
  {
    if (!Directory.Exists(_outputDir))
    {
      Directory.CreateDirectory(_outputDir);
    }

    // Step 1 — pre-generate all parameters deterministically (single thread)
    var items = PreGenerate(count);

    Console.WriteLine($"Starting parallel generation with {_parallelism} worker(s)...");
    Console.WriteLine();

    // Step 2 — manifest array (pre-allocated, each slot written by a single thread)
    var manifest = new string[count + 1];
    manifest[0] = "Index,Format,Channels,BitDepth,Bitrate,BitrateMode," +
                  "SampleRate,Duration,VbrQuality,FileName,Status";

    var wallClock = Stopwatch.StartNew();

    // Step 3 — run FFmpeg in parallel and fill manifest
    // Using Parallel.ForEach to control the degree of parallelism and ensure thread-safe updates to counters and manifest
    Parallel.ForEach(
      items,
      new ParallelOptions { MaxDegreeOfParallelism = _parallelism },
      item =>
      {
        var isOk = RunFfmpeg(item.Params, item.FilePath);
        var total = isOk
          ? Interlocked.Increment(ref _succeeded)
          : Interlocked.Increment(ref _failed);

        total = _succeeded + _failed;
        Console.WriteLine($"[{total,4}/{count}] {(isOk ? "OK    " : "FAILED")} {Path.GetFileName(item.FilePath)}");

        manifest[item.Index + 1] = BuildManifestLine(
          item.Index,
          item.Params,
          Path.GetFileName(item.FilePath),
          isOk ? "OK" : "FAILED");
      });

    wallClock.Stop();

    // Step 3 — write manifest
    var manifestPath = Path.Combine(_outputDir, "manifest.csv");
    File.WriteAllLines(manifestPath, manifest);

    Console.WriteLine();
    Console.WriteLine($"Finished in {wallClock.Elapsed:hh\\:mm\\:ss}");
    Console.WriteLine($"  OK     : {_succeeded}");
    Console.WriteLine($"  FAILED : {_failed}");
    Console.WriteLine($"  Manifest: {manifestPath}");
  }

  // Pre-generation
  private List<GenerationItem> PreGenerate(int count)
  {
    var items = new List<GenerationItem>(count);
    for (var i = 0; i < count; i++)
    {
      var p = _paramGen.GenerateRandom();
      var name = BuildFileName(i, p);
      items.Add(new GenerationItem(i, p, Path.Combine(_outputDir, name)));
    }

    return items;
  }

  // FFmpeg invocation
  private bool RunFfmpeg(AudioParameters p, string outputPath)
  {
    var args = _cmdBuilder.BuildArguments(p, outputPath);
    try
    {
      var psi = new ProcessStartInfo
      {
        FileName = _ffmpegPath,
        Arguments = args,
        UseShellExecute = false,
        CreateNoWindow = true,
        RedirectStandardOutput = true,
        RedirectStandardError  = true
      };

      using var proc = Process.Start(psi);
      if (proc is null)
      {
        return false;
      }

      // Read both streams asynchronously to prevent deadlock
      var readStdout = Task.Run(() =>
      {
        var output = proc.StandardOutput.ReadToEnd();
#if TRACE_FFMPEG
        if (!string.IsNullOrEmpty(output))
        {
          Console.Write(output);
        }
#endif
      });
      var readStderr = Task.Run(() =>
      {
        var output = proc.StandardError.ReadToEnd();
#if TRACE_FFMPEG
        if (!string.IsNullOrEmpty(output))
        {
          Console.Write(output);
        }
#endif
      });

      bool exited = proc.WaitForExit(60_000);
      if (!exited)
      {
        proc.Kill();
        return false;
      }

      Task.WaitAll(readStdout, readStderr);
      return proc.ExitCode == 0 && File.Exists(outputPath);
    }
    catch (Exception ex)
    {
      Console.Error.WriteLine($"[ERROR] {Path.GetFileName(outputPath)}: {ex.Message}");
      return false;
    }
  }

  #region Helpers

  private static string BuildFileName(int index, AudioParameters p)
  {
    var mode = p.BitrateMode == BitrateMode.VBR ?
      $"VBR{p.VbrQuality}" :
      "CBR";
    return $"{index:D4}_{p.Format}_{p.Channels}ch_{p.SampleRate}Hz_" +
      $"{p.BitDepth}bit_{p.Bitrate}kbps_{mode}.mka";
  }

  private static string BuildManifestLine(int index, AudioParameters p, string fileName, string status) =>
    $"{index},{p.Format},{p.Channels},{p.BitDepth},{p.Bitrate}," +
    $"{p.BitrateMode},{p.SampleRate},{p.DurationSeconds},{p.VbrQuality}," +
    $"{fileName},{status}";

  private record GenerationItem(int Index, AudioParameters Params, string FilePath);

  #endregion
}
