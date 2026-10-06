#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

namespace MediaInfo.Model
{
  /// <summary>
  /// Provides properties and overridden methods for the analyze stream
  /// and contains information about media stream.
  /// </summary>
  /// <seealso cref="MediaStream" />
  public abstract class LanguageMediaStream : MediaStream
  {
    /// <summary>
    /// Gets the media stream language.
    /// </summary>
    /// <value>
    /// The media stream language.
    /// </value>
    public string Language { get; set; } = default!;

    /// <summary>
    /// Gets the media stream language tag in IETF BCP 47 format.
    /// </summary>
    /// <value>
    /// The media stream language tag.
    /// </value>
    public string LanguageIetf { get; set; } = default!;

    /// <summary>
    /// Gets the media stream LCID.
    /// </summary>
    /// <value>
    /// The media stream LCID.
    /// </value>
    public int Lcid { get; set; }

    /// <summary>
    /// Gets a value indicating whether this <see cref="LanguageMediaStream"/> is default.
    /// </summary>
    /// <value>
    ///   <c>true</c> if default; otherwise, <c>false</c>.
    /// </value>
    public bool Default { get; set; }

    /// <summary>
    /// Gets a value indicating whether this <see cref="LanguageMediaStream"/> is forced.
    /// </summary>
    /// <value>
    ///   <c>true</c> if forced; otherwise, <c>false</c>.
    /// </value>
    public bool Forced { get; set; }

    /// <summary>
    /// Gets the stream size.
    /// </summary>
    /// <value>
    /// The stream size (bytes).
    /// </value>
    public long StreamSize { get; set; }

    /// <summary>
    /// Code language.
    /// </summary>
    public string LanguageId { get; internal set; }
    public string LanguageString1 { get; internal set; }
    public string LanguageString2 { get; internal set; }
    public string LanguageString3 { get; internal set; }
    public string LanguageString4 { get; internal set; }
  }
}