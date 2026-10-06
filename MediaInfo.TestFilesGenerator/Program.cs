#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

using System;
using System.CommandLine;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MediaInfo.TestFilesGenerator;

internal static class Program
{
  static async Task<int> Main(string[] args)
  {
    var outputDir = new Option<string>("--output", "-o")
    {
      AllowMultipleArgumentsPerToken = false,
      DefaultValueFactory = (r) => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestAudio"),
      Description = "Output folder"
    };
    var seed = new Option<int>("--seed", "-s")
    {
      AllowMultipleArgumentsPerToken = false,
      DefaultValueFactory = (r) => 42,
      Description = "RNG seed"
    };
    var count = new Option<int>("--count", "-c")
    {
      AllowMultipleArgumentsPerToken = false,
      DefaultValueFactory = (r) => 3000,
      Description = "Number of files to generate"
    };
    var ffmpegPath = new Option<string>("--ffmpeg", "-f")
    {
      AllowMultipleArgumentsPerToken = false,
      Description = "Path to ffmpeg binary including ffmpeg executable (default: ffmpeg, i.e. must be in PATH)",
      DefaultValueFactory = (r) => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg")
    };
    var parallelism = new Option<int>("--parallelism", "-p")
    {
      AllowMultipleArgumentsPerToken = false,
      DefaultValueFactory = (r) => Environment.ProcessorCount,
      Description = "Number of parallel workers (default: CPU count)"
    };
    var rootCommand = new RootCommand("MKA Test File Generator")
    {
      outputDir,
      seed,
      count,
      ffmpegPath,
      parallelism
    };

    var parseResult = rootCommand.Parse(args);
    await parseResult.InvokeAsync();
    if (parseResult.Errors.Count > 0)
    {
      return -1;
    }

    var outputDirValue = parseResult.GetValue<string>(outputDir);
    var ffmpegPathValue = parseResult.GetValue<string>(ffmpegPath);
    var parallelismValue = parseResult.GetValue<int>(parallelism);
    var seedValue = parseResult.GetValue<int>(seed);
    var countValue = parseResult.GetValue<int>(count);

    Console.WriteLine();
    var previousForegroundColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"  Output      : {outputDirValue}");
    Console.WriteLine($"  Seed        : {seedValue}");
    Console.WriteLine($"  Count       : {countValue}");
    Console.WriteLine($"  FFmpeg      : {ffmpegPathValue}");
    Console.WriteLine($"  Parallelism : {parallelismValue}");
    Console.WriteLine();
    Console.ForegroundColor = previousForegroundColor;

    if (!CheckFfmpeg(ffmpegPathValue!))
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Error.WriteLine("ERROR: FFmpeg not found or not executable.");
      Console.Error.WriteLine("       Install FFmpeg and add it to PATH, or pass the full path as argument --ffmpeg.");
      Console.ForegroundColor = previousForegroundColor;
      return 1;
    }

    await new FileGenerator(outputDirValue!, ffmpegPathValue!, seedValue, parallelismValue)
      .Generate(countValue);

    return 0;
  }

  #region Helpers

  private static bool CheckFfmpeg(string ffmpegPath)
  {
    try
    {
      var psi = new ProcessStartInfo
      {
        FileName = ffmpegPath,
        Arguments = "-version",
        UseShellExecute = false,
        CreateNoWindow = true,
        RedirectStandardOutput = true,
        RedirectStandardError  = true
      };
      
      using var p = Process.Start(psi);
      p?.WaitForExit(5_000);
      return p?.ExitCode == 0;
    }
    catch
    {
      return false;
    }
  }

  #endregion
}
