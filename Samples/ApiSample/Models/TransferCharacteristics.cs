#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApiSample.Models;

/// <summary>
/// Describes video transfer characteristics
/// </summary>
[DataContract]
[JsonConverter(typeof(JsonStringEnumConverter<TransferCharacteristic>))]
public enum TransferCharacteristic
{
    /// <summary>
    /// Printing density
    /// </summary>
    [EnumMember(Value = "printingDensity")]
    [JsonStringEnumMemberName("printingDensity")]
    PrintingDensity,

    /// <summary>
    /// The linear transfer
    /// </summary>
    [EnumMember(Value = "linear")]
    [JsonStringEnumMemberName("linear")]
    Linear,

    /// <summary>
    /// The logarithmic transfer
    /// </summary>
    [EnumMember(Value = "logarithmic")]
    [JsonStringEnumMemberName("logarithmic")]
    Logarithmic,

    /// <summary>
    /// BT.601 NTSC
    /// </summary>
    [EnumMember(Value = "bt.601.ntsc")]
    [JsonStringEnumMemberName("bt.601.ntsc")]
    BT601NTSC,

    /// <summary>
    /// BT.601 PAL
    /// </summary>
    [EnumMember(Value = "bt.601.pal")]
    [JsonStringEnumMemberName("bt.601.pal")]
    BT601PAL,

    /// <summary>
    /// Composite NTSC
    /// </summary>
    [EnumMember(Value = "composite.ntsc")]
    [JsonStringEnumMemberName("composite.ntsc")]
    CompositeNTSC,

    /// <summary>
    /// Composite PAL
    /// </summary>
    [EnumMember(Value = "composite.pal")]
    [JsonStringEnumMemberName("composite.pal")]
    CompositePAL,

    /// <summary>
    /// BT.709
    /// </summary>
    [EnumMember(Value = "bt.709")]
    [JsonStringEnumMemberName("bt.709")]
    BT709,

    /// <summary>
    /// ADX
    /// </summary>
    [EnumMember(Value = "adx")]
    [JsonStringEnumMemberName("adx")]
    ADX,

    /// <summary>
    /// SMPTE 274M
    /// </summary>
    [EnumMember(Value = "smpte.274m")]
    [JsonStringEnumMemberName("smpte.274m")]
    SMPTE274M,

    /// <summary>
    /// Z (depth) - linear
    /// </summary>
    [EnumMember(Value = "zlinear")]
    [JsonStringEnumMemberName("zlinear")]
    ZLinear,

    /// <summary>
    /// Z (depth) - homogeneous
    /// </summary>
    [EnumMember(Value = "zhomogeneous")]
    [JsonStringEnumMemberName("zhomogeneous")]
    ZHomogeneous
}