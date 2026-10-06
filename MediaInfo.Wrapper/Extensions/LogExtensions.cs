#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

using System;
using System.Text;

namespace MediaInfo
{
  /// <summary>A log extensions.</summary>
  public static class LogExtensions
  {
    /// <summary>Logs a verbose message.</summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The message.</param>
    /// <param name="parameters">A variable-length parameters list containing message parameters.</param>
    public static void LogVerbose(this ILogger logger, string message, params object[] parameters) =>
      logger.Log(LogLevel.Verbose, message, parameters);

    /// <summary>Logs a debug message.</summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The message.</param>
    /// <param name="parameters">A variable-length parameters list containing message parameters.</param>
    public static void LogDebug(this ILogger logger, string message, params object[] parameters) =>
      logger.Log(LogLevel.Debug, message, parameters);

    /// <summary>Logs a information message.</summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The message.</param>
    /// <param name="parameters">A variable-length parameters list containing message parameters.</param>
    public static void LogInformation(this ILogger logger, string message, params object[] parameters) =>
      logger.Log(LogLevel.Information, message, parameters);

    /// <summary>Logs a warning message.</summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The message.</param>
    /// <param name="parameters">A variable-length parameters list containing message parameters.</param>
    public static void LogWarning(this ILogger logger, string message, params object[] parameters) =>
      logger.Log(LogLevel.Warning, message, parameters);

    /// <summary>This method logs a warning message with an exception details.</summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The source exception object.</param>
    /// <param name="message">The <paramref name="message"/> to which the exception details will be appended.</param>
    /// <param name="parameters">A variable-length parameters list containing message parameters.</param>
    public static void LogWarning(this ILogger logger, Exception? exception, string message, params object[] parameters)
    {
      var warningMessage = string.Format(message, parameters);
      if (exception is not null)
      {
        var msg = new StringBuilder()
          .AppendFormat(message, parameters)
          .AppendLine()
          .Append("Exception: ")
          .AppendLine(exception.Message)
          .AppendLine("Callstack:")
          .Append(exception.StackTrace);

        warningMessage = msg.ToString();
      }

      logger.Log(LogLevel.Warning, warningMessage);
    }

    /// <summary>Logs a error message.</summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The message.</param>
    /// <param name="parameters">A variable-length parameters list containing message parameters.</param>
    public static void LogError(this ILogger logger, string message, params object[] parameters) =>
      logger.Log(LogLevel.Error, message, parameters);

    /// <summary>Logs a error message.</summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The source exception object.</param>
    /// <param name="message">The message.</param>
    /// <param name="parameters">A variable-length parameters list containing message parameters.</param>
    public static void LogError(this ILogger logger, Exception? exception, string message, params object[] parameters)
    {
      var errorMessage = string.Format(message, parameters);
      if (exception is not null)
      {
        var msg = new StringBuilder()
          .AppendFormat(message, parameters)
          .AppendLine()
          .Append("Exception: ")
          .AppendLine(exception.Message)
          .AppendLine("Callstack:")
          .Append(exception.StackTrace);

        errorMessage = msg.ToString();
      }

      logger.Log(LogLevel.Error, errorMessage);
    }

    /// <summary>Logs a critical message.</summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="message">The message.</param>
    /// <param name="parameters">A variable-length parameters list containing message parameters.</param>
    public static void LogCritical(this ILogger logger, string message, params object[] parameters) =>
      logger.Log(LogLevel.Critical, message, parameters);

    /// <summary>Logs a critical message.</summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="exception">The source exception object.</param>
    /// <param name="message">The message.</param>
    /// <param name="parameters">A variable-length parameters list containing message parameters.</param>
    public static void LogCritical(this ILogger logger, Exception? exception, string message, params object[] parameters)
    {
      var errorMessage = string.Format(message, parameters);
      if (exception is not null)
      {
        var msg = new StringBuilder()
          .AppendFormat(message, parameters)
          .AppendLine()
          .Append("Exception: ")
          .AppendLine(exception.Message)
          .AppendLine("Callstack:")
          .Append(exception.StackTrace);

        errorMessage = msg.ToString();
      }

      logger.Log(LogLevel.Critical, errorMessage);
    }
  }
}
