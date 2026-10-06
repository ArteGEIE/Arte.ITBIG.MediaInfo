#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

namespace MediaInfo.TestFilesGenerator.Models;

/// <summary>
/// Specifies the supported audio encoding formats.
/// </summary>
/// <remarks>Use this enumeration to indicate the audio format for encoding, decoding, or processing audio
/// data. The values correspond to common audio codecs and file types.</remarks>
public enum AudioFormat
{
    /// <summary>
    /// Represents the AC-3 (Audio Codec 3) audio format specification.
    /// </summary>
    AC3,

    /// <summary>
    /// Represents the DTS (Data Transformation Services) functionality or related data structure.
    /// </summary>
    DTS,

    /// <summary>
    /// Represents the Advanced Audio Coding (AAC) audio format.
    /// </summary>
    AAC,

    /// <summary>
    /// Represents a WAV audio file format type.
    /// </summary>
    Wav
}
