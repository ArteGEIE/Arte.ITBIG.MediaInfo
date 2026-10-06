#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

namespace MediaInfo.TestFilesGenerator;

/// <summary>
/// Static tables of valid parameter values per audio format.
/// </summary>
internal static class FormatConstraints
{
  // AC3 (Dolby Digital)
  // Standard ATSC bitrate set; only 48 kHz is valid for AC3.
  internal static readonly int[] Ac3Channels = { 1, 2, 4, 6 };
  internal static readonly double[] Ac3SampleRates = { 48000.0 };
  internal static readonly int[] Ac3Bitrates =
  {
    32, 40, 48, 56, 64, 80, 96, 112, 128,
    160, 192, 224, 256, 320, 384, 448, 512, 576, 640
  };

  // DTS
  // FFmpeg DCA encoder; valid standard CBR bitrates.
  internal static readonly int[] DtsChannels = { 1, 2, 4, 6 };
  internal static readonly double[] DtsSampleRates = { 44100.0, 48000.0 };
  internal static readonly int[] DtsBitrates =
  {
      128, 192, 256, 320, 384, 448, 512,
      576, 640, 768, 960, 1024, 1152, 1280, 1344, 1409, 1509
  };

  // AAC
  internal static readonly int[] AacChannels = { 1, 2, 4, 6, 8 };
  internal static readonly double[] AacSampleRates = { 22050.0, 32000.0, 44100.0, 48000.0 };
  internal static readonly int[] AacBitrates =
  {
      32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320
  };
  /// <summary>VBR quality levels for FFmpeg native aac encoder.</summary>
  internal static readonly int[] AacVbrQualities = { 1, 2, 3, 4, 5 };

  // WAV / PCM in MKA
  internal static readonly int[] WavChannels = { 1, 2, 4, 6, 8 };
  internal static readonly int[] WavBitDepths = { 8, 16, 24, 32 };
  internal static readonly double[] WavSampleRates =
  {
    8000.0, 11025.0, 16000.0, 22050.0, 32000.0, 44100.0, 48000.0, 96000.0
  };

  // Shared
  internal static readonly int[] Durations = { 3, 5, 7, 10, 15, 20, 30 };
}
