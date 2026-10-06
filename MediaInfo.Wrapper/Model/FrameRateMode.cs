#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

namespace MediaInfo.Model;

/// <summary>
/// Defines whether the frame rate is constant or variable.
/// </summary>
public enum FrameRateMode
{
  /// <summary>
  /// The stream uses a constant frame rate.
  /// </summary>
  Constant,

  /// <summary>
  /// The stream uses a variable frame rate.
  /// </summary>
  Variable
}
