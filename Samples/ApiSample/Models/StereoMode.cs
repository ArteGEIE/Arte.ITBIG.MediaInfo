#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApiSample.Models;

/// <summary>
/// Describes 3D stereo mode
/// </summary>
[DataContract]
[JsonConverter(typeof(JsonStringEnumConverter<StereoMode>))]
public enum StereoMode
{
    /// <summary>
    /// No 3D (mono)
    /// </summary>
    [EnumMember(Value = "mono")]
    [JsonStringEnumMemberName("mono")]
    Mono,

    /// <summary>
    /// Stereo mode without additional info
    /// </summary>
    [EnumMember(Value = "stereo")]
    [JsonStringEnumMemberName("stereo")]
    Stereo,

    /// <summary>
    /// The side by side left eye is first
    /// </summary>
    [EnumMember(Value = "sbs-left")]
    [JsonStringEnumMemberName("sbs-left")]
    SideBySideLeft,

    /// <summary>
    /// The top bottom right eye is first
    /// </summary>
    [EnumMember(Value = "tb-right")]
    [JsonStringEnumMemberName("tb-right")]
    TopBottomRight,

    /// <summary>
    /// The top bottom left eye is first
    /// </summary>
    [EnumMember(Value = "tb-left")]
    [JsonStringEnumMemberName("tb-left")]
    TopBottomLeft,

    /// <summary>
    /// The checkerboard right eye is first
    /// </summary>
    [EnumMember(Value = "checkerboard-right")]
    [JsonStringEnumMemberName("checkerboard-right")]
    CheckerboardRight,

    /// <summary>
    /// The checkerboard left eye is first
    /// </summary>
    [EnumMember(Value = "checkerboard-left")]
    [JsonStringEnumMemberName("checkerboard-left")]
    CheckerboardLeft,

    /// <summary>
    /// The row interleaved right eye is first
    /// </summary>
    [EnumMember(Value = "row-interleaved-right")]
    [JsonStringEnumMemberName("row-interleaved-right")]
    RowInterleavedRight,

    /// <summary>
    /// The row interleaved left eye is first
    /// </summary>
    [EnumMember(Value = "row-interleaved-left")]
    [JsonStringEnumMemberName("row-interleaved-left")]
    RowInterleavedLeft,

    /// <summary>
    /// The column interleaved right eye is first
    /// </summary>
    [EnumMember(Value = "column-interleaved-right")]
    [JsonStringEnumMemberName("column-interleaved-right")]
    ColumnInterleavedRight,

    /// <summary>
    /// The column interleaved left eye is first
    /// </summary>
    [EnumMember(Value = "column-interleaved-left")]
    [JsonStringEnumMemberName("column-interleaved-left")]
    ColumnInterleavedLeft,

    /// <summary>
    /// The anaglyph cyan-red
    /// </summary>
    [EnumMember(Value = "anaglyph-cyan-red")]
    [JsonStringEnumMemberName("anaglyph-cyan-red")]
    AnaglyphCyanRed,

    /// <summary>
    /// The side by side right eye is first
    /// </summary>
    [EnumMember(Value = "sbs-right")]
    [JsonStringEnumMemberName("sbs-right")]
    SideBySideRight,

    /// <summary>
    /// The anaglyph green-magenta
    /// </summary>
    [EnumMember(Value = "anaglyph-green-magenta")]
    [JsonStringEnumMemberName("anaglyph-green-magenta")]
    AnaglyphGreenMagenta,

    /// <summary>
    /// The both eyes laced left eye is first
    /// </summary>
    [EnumMember(Value = "both-laced-left")]
    [JsonStringEnumMemberName("both-laced-left")]
    BothEyesLacedLeft,

    /// <summary>
    /// The both eyes laced right eye is first
    /// </summary>
    [EnumMember(Value = "both-laced-right")]
    [JsonStringEnumMemberName("both-laced-right")]
    BothEyesLacedRight
}