#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApiSample.Models;

/// <summary>
/// Describes video aspect ratio
/// </summary>
[DataContract]
[JsonConverter(typeof(JsonStringEnumConverter<AspectRatio>))]
public enum AspectRatio
{
    /// <summary>
    /// The opaque (1:1)
    /// </summary>
    [EnumMember(Value = "opaque")]
    [JsonStringEnumMemberName("opaque")]
    Opaque,

    /// <summary>
    /// The high end data graphics (5:4)
    /// </summary>
    [EnumMember(Value = "highEndDataGraphics")]
    [JsonStringEnumMemberName("highEndDataGraphics")]
    HighEndDataGraphics,

    /// <summary>
    /// The full screen (4:3)
    /// </summary>
    [EnumMember(Value = "fullScreen")]
    [JsonStringEnumMemberName("fullScreen")]
    FullScreen,

    /// <summary>
    /// The standard slides (3:3)
    /// </summary>
    [EnumMember(Value = "standardSlides")]
    [JsonStringEnumMemberName("standardSlides")]
    StandardSlides,

    /// <summary>
    /// The digital SLR cameras (3:2)
    /// </summary>
    [EnumMember(Value = "digitalSlrCameras")]
    [JsonStringEnumMemberName("digitalSlrCameras")]
    DigitalSlrCameras,

    /// <summary>
    /// The High Definition TV (16:9)
    /// </summary>
    [EnumMember(Value = "hdtv")]
    [JsonStringEnumMemberName("hdtv")]
    HighDefinitionTv,

    /// <summary>
    /// The wide screen display (16:10)
    /// </summary>
    [EnumMember(Value = "wideScreenDisplay")]
    [JsonStringEnumMemberName("wideScreenDisplay")]
    WideScreenDisplay,

    /// <summary>
    /// The wide screen (1.85:1)
    /// </summary>
    [EnumMember(Value = "wideScreen")]
    [JsonStringEnumMemberName("wideScreen")]
    WideScreen,

    /// <summary>
    /// The cinema scope (21:9)
    /// </summary>
    [EnumMember(Value = "cinemaScope")]
    [JsonStringEnumMemberName("cinemaScope")]
    CinemaScope
}