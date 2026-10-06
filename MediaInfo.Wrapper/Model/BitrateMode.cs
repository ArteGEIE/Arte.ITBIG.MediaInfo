#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

namespace MediaInfo.Model
{
  /// <summary>
  /// Defines the bitrate control mode used by an encoded stream.
  /// </summary>
  public enum BitrateMode : byte
  {
    /// <summary>
    /// Constant quality encoding mode.
    /// </summary>
    Cq,

    /// <summary>
    /// Constant bitrate encoding mode.
    /// </summary>
    Cbr,

    /// <summary>
    /// Variable bitrate encoding mode.
    /// </summary>
    Vbr
  }
}
