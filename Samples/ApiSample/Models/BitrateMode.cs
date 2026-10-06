#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApiSample.Models;

/// <summary>
/// Describes bitrate possible modes
/// </summary>
[DataContract]
[JsonConverter(typeof(JsonStringEnumConverter<BitrateMode>))]
public enum BitrateMode : byte
{
    /// <summary>
    /// Constant quality mode
    /// </summary>
    [EnumMember(Value = "constantQuality")]
    [JsonStringEnumMemberName("constantQuality")]
    Cq,

    /// <summary>
    /// Constant bitrate mode
    /// </summary>
    [EnumMember(Value = "constantBitrate")]
    [JsonStringEnumMemberName("constantBitrate")]
    Cbr,

    /// <summary>
    /// Variable bitrate mode
    /// </summary>
    [EnumMember(Value = "variableBitrate")]
    [JsonStringEnumMemberName("variableBitrate")]
    Vbr
}
