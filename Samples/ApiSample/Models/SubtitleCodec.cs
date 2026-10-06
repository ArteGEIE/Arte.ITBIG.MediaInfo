#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApiSample.Models;

/// <summary>
/// Defines constants for different kind of subtitles.
/// </summary>
[DataContract]
[JsonConverter(typeof(JsonStringEnumConverter<SubtitleCodec>))]
public enum SubtitleCodec
{

    /// <summary>
    /// The undefined type.
    /// </summary>
    [EnumMember(Value = "undefined")]
    [JsonStringEnumMemberName("undefined")]
    Undefined,

    /// <summary>
    /// The Advanced SubStation Alpha subtitles.
    /// </summary>
    [EnumMember(Value = "ass")]
    [JsonStringEnumMemberName("ass")]
    Ass,

    /// <summary>
    /// The BMP image subtitles.
    /// </summary>
    [EnumMember(Value = "bmp")]
    [JsonStringEnumMemberName("bmp")]
    ImageBmp,

    /// <summary>
    /// The  SubStation Alpha subtitles.
    /// </summary>
    [EnumMember(Value = "ssa")]
    [JsonStringEnumMemberName("ssa")]
    Ssa,

    /// <summary>
    /// The Advanced SubStation Alpha text subtitles.
    /// </summary>
    [EnumMember(Value = "text-ass")]
    [JsonStringEnumMemberName("text-ass")]
    TextAss,

    /// <summary>
    /// The SubStation Alpha text subtitles.
    /// </summary>
    [EnumMember(Value = "text-ssa")]
    [JsonStringEnumMemberName("text-ssa")]
    TextSsa,

    /// <summary>
    /// The Universal Subtitle Format text subtitles.
    /// </summary>
    [EnumMember(Value = "text-usf")]
    [JsonStringEnumMemberName("text-usf")]
    TextUsf,

    /// <summary>
    /// The Unicode text subtitles.
    /// </summary>
    [EnumMember(Value = "text-utf8")]
    [JsonStringEnumMemberName("text-utf8")]
    TextUtf8,

    /// <summary>
    /// The Universal Subtitle Format subtitles.
    /// </summary>
    [EnumMember(Value = "usf")]
    [JsonStringEnumMemberName("usf")]
    Usf,

    /// <summary>
    /// The Unicode subtitles.
    /// </summary>
    [EnumMember(Value = "utf8")]
    [JsonStringEnumMemberName("utf8")]
    Utf8,

    /// <summary>
    /// The VOB SUB subtitles (DVD subtitles).
    /// </summary>
    [EnumMember(Value = "vobsup")]
    [JsonStringEnumMemberName("vobsup")]
    Vobsub,

    /// <summary>
    /// The Presentation Grapic Stream Subtitle Format subtitles
    /// </summary>
    [EnumMember(Value = "hdmv-pgs")]
    [JsonStringEnumMemberName("hdmv-pgs")]
    HdmvPgs,

    /// <summary>
    /// The HDMV Text Subtitle Format subtitles
    /// </summary>
    [EnumMember(Value = "hdmv-text")]
    [JsonStringEnumMemberName("hdmv-text")]
    HdmvTextst
}