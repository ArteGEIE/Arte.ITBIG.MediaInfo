#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

using System;
using MediaInfo.TestFilesGenerator.Models;

namespace MediaInfo.TestFilesGenerator;

/// <summary>
/// Generates <see cref="AudioParameters"/> using a seeded <see cref="Random"/>
/// so that the same seed always produces the same file set.
/// </summary>
/// <param name="seed">The RNG seed.</param>
internal sealed class ParameterGenerator(int seed)
{
  private static readonly AudioFormat[] AllFormats = 
  {
      AudioFormat.AC3,
      AudioFormat.DTS,
      AudioFormat.AAC,
      AudioFormat.Wav
  };

  private readonly Random _rng = new Random(seed);

  /// <summary>
  /// Picks a random format, then generates valid parameters for it.
  /// </summary>
  public AudioParameters GenerateRandom() =>
    Generate(AllFormats[_rng.Next(AllFormats.Length)]);

  public AudioParameters Generate(AudioFormat format) =>
    format switch
    {
      AudioFormat.AC3 => GenerateAc3(),
      AudioFormat.DTS => GenerateDts(),
      AudioFormat.AAC => GenerateAac(),
      AudioFormat.Wav => GenerateWav(),
      _ => throw new ArgumentOutOfRangeException(nameof(format)),
    };

  #region Format-specific builders

  private AudioParameters GenerateAc3()
  {
    int channels = Pick(FormatConstraints.Ac3Channels);
    return new(
      AudioFormat.AC3,
      channels,
      16,
      Pick(GetAc3Bitrates(channels)),
      BitrateMode.CBR,
      Pick(FormatConstraints.Ac3SampleRates),
      Pick(FormatConstraints.Durations),
      0
    );
  }

  private AudioParameters GenerateDts() =>
    new(
      AudioFormat.DTS,
      Pick(FormatConstraints.DtsChannels),
      16,
      Pick(FormatConstraints.DtsBitrates),
      BitrateMode.CBR,
      Pick(FormatConstraints.DtsSampleRates),
      Pick(FormatConstraints.Durations),
      0
    );

  private AudioParameters GenerateAac()
  {
    bool isVbr = _rng.NextDouble() < 0.35; // ~35 % of AAC files use VBR
    return new AudioParameters(
      AudioFormat.AAC,
      Pick(FormatConstraints.AacChannels),
      16,
      isVbr ? 0 : Pick(FormatConstraints.AacBitrates),
      isVbr ? BitrateMode.VBR : BitrateMode.CBR,
      Pick(FormatConstraints.AacSampleRates),
      Pick(FormatConstraints.Durations),
      isVbr ? Pick(FormatConstraints.AacVbrQualities) : 0
    );
  }

  private AudioParameters GenerateWav()
  {
    var bitDepth = Pick(FormatConstraints.WavBitDepths);
    var channels = Pick(FormatConstraints.WavChannels);
    var sampleRate = Pick(FormatConstraints.WavSampleRates);
    return new AudioParameters(
      AudioFormat.Wav,
      channels,
      bitDepth,
      channels * bitDepth * (int)sampleRate / 1000, // kbps, calculated
      BitrateMode.CBR,
      sampleRate,
      Pick(FormatConstraints.Durations),
      0
    );
  }

  #endregion

  #region Helpers

  private T Pick<T>(T[] arr) => arr[_rng.Next(arr.Length)];

  /// <summary>
  /// Returns the subset of AC3 bitrates that are valid for the given
  /// channel count (encoder rejects too-low bitrates for wide configs).
  /// </summary>
  private static int[] GetAc3Bitrates(int channels) =>
    channels switch
    {
        1 => [32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192],
        2 => [32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320, 384],
        4 => [96, 112, 128, 160, 192, 224, 256, 320, 384, 448],
        _ => [192, 224, 256, 320, 384, 448, 512, 576, 640],// 6ch (5.1)
    };

  #endregion
}
