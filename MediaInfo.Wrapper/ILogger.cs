﻿#region Copyright (C) 2017-2020 Yaroslav Tatarenko

// Copyright (C) 2017-2020 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2020 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

namespace MediaInfo
{
  /// <summary>Values that represent log levels.</summary>
  public enum LogLevel
  {
    /// <summary>
    /// The verbose level
    /// </summary>
    Verbose,

    /// <summary>
    /// The debug level
    /// </summary>
    Debug,

    /// <summary>
    /// The information level
    /// </summary>
    Information,

    /// <summary>
    /// The warning level
    /// </summary>
    Warning,

    /// <summary>
    /// The error level
    /// </summary>
    Error,

    /// <summary>
    /// The critical error level
    /// </summary>
    Critical
  }

  /// <summary>Interface for logger.</summary>
  public interface ILogger
  {
    /// <summary>Logs message.</summary>
    /// <param name="loglevel">The log level.</param>
    /// <param name="message">The message.</param>
    /// <param name="parameters">A variable-length parameters list containing message parameters.</param>
    void Log(LogLevel loglevel, string message, params object[] parameters);
  }
}