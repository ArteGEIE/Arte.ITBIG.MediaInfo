#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

using System.Text;
using MediaInfo.TestFilesGenerator.Models;

namespace MediaInfo.TestFilesGenerator;

/// <summary>Builds the FFmpeg argument string for a single MKA file.</summary>
internal sealed class FfmpegCommandBuilder
{
  /// <summary>
  /// Builds FFmpeg arguments (not including the executable name) for
  /// the given <paramref name="p"/> writing to <paramref name="outputPath"/>.
  /// <para>
  /// Input: <c>anullsrc</c> lavfi filter (silence) — zero encoding overhead,
  /// correct channel layout, and sample rate already set on the source.
  /// </para>
  /// </summary>
  public string BuildArguments(AudioParameters p, string outputPath)
  {
    var sb = new StringBuilder();

    // -y           : overwrite without asking
    // anullsrc     : silent audio with the exact channel layout + sample rate
    // -t           : duration
    sb.Append("-y");
    sb.Append($" -f lavfi -i \"anullsrc=channel_layout={GetLayout(p.Channels)}:sample_rate={p.SampleRate}\"");
    sb.Append($" -t {p.DurationSeconds}");

    // Codec + encoding parameters
    switch (p.Format)
    {
      case AudioFormat.AC3:
        sb.Append($" -c:a ac3 -b:a {p.Bitrate}k");
        break;

      case AudioFormat.DTS:
        // FFmpeg DCA encoder requires -strict -2 on some builds
        sb.Append($" -c:a dca -b:a {p.Bitrate}k -strict -2");
        break;

      case AudioFormat.AAC:
        sb.Append(" -c:a aac");
        if (p.BitrateMode == BitrateMode.VBR)
        {
          sb.Append($" -q:a {p.VbrQuality * 0.4}");
        }
        else
        {
          sb.Append($" -b:a {p.Bitrate}k");
        }

        break;

      case AudioFormat.Wav:
        // PCM stored in MKA; sample rate already set via anullsrc
        sb.Append($" -c:a {GetPcmCodec(p.BitDepth)}");
        break;
    }

    sb.Append($" \"{outputPath}\"");
    return sb.ToString();
  }

  // Channel layout names recognised by FFmpeg
  private static string GetLayout(int channels) =>
    channels switch
    {
      1 => "mono",
      2 => "stereo",
      4 => "quad",// FL FR BL BR  — valid for AC3 (2/2) and DTS
      6 => "5.1",
      8 => "7.1",
      _ => "stereo",
    };

  // PCM codec name for the requested bit depth
  private static string GetPcmCodec(int bitDepth) =>
    bitDepth switch
    {
      8 => "pcm_u8",
      16 => "pcm_s16le",
      24 => "pcm_s24le",
      32 => "pcm_s32le",
      _ => "pcm_s16le",
    };
}
