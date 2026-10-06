#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

namespace MediaInfo.TestFilesGenerator.Models;

/// <summary>Pseudo-random parameters for a single MKA test file.</summary>
/// <param name="Format">Audio format (e.g. MP3, AAC).</param>
/// <param name="Channels">Number of audio channels (e.g. 2 for stereo, 6 for 5.1 surround).</param>
/// <param name="BitDepth">Audio bit depth (e.g. 16, 24).</param>
/// <param name="Bitrate">Audio bitrate in bits per second (e.g. 128000 for 128 kbps).</param>
/// <param name="BitrateMode">Bitrate mode (e.g. CBR, VBR).</param>
/// <param name="SampleRate">Audio sample rate in Hz (e.g. 44100.0, 48000.0).</param>
/// <param name="DurationSeconds">Duration of the audio in seconds.</param>
/// <param name="VbrQuality">VBR quality level (1–5), valid only when BitrateMode == VBR (AAC).</param>
internal record AudioParameters(
  AudioFormat Format,
  int Channels,
  int BitDepth,
  int Bitrate,
  BitrateMode BitrateMode,
  double SampleRate,
  int DurationSeconds,
  int VbrQuality);
