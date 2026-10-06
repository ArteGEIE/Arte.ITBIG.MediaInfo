#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApiSample.Models;

/// <summary>
/// Defines constants for different kind of audio codecs.
/// </summary>
[DataContract]
[JsonConverter(typeof(JsonStringEnumConverter<AudioCodec>))]
public enum AudioCodec
{
    /// <summary>
    /// The undefined audio codec
    /// </summary>
    [EnumMember(Value = "undefined")]
    [JsonStringEnumMemberName("undefined")]
    Undefined,

    /// <summary>
    /// MPEG Layer 1
    /// </summary>
    [EnumMember(Value = "mpeg1")]
    [JsonStringEnumMemberName("mpeg1")]
    MpegLayer1,

    /// <summary>
    /// MPEG Layer 2
    /// </summary>
    [EnumMember(Value = "mpeg2")]
    [JsonStringEnumMemberName("mpeg2")]
    MpegLayer2,

    /// <summary>
    /// MPEG Layer 3
    /// </summary>
    [EnumMember(Value = "mpeg3")]
    [JsonStringEnumMemberName("mpeg3")]
    MpegLayer3,

    /// <summary>
    /// PCM big-endian int
    /// </summary>
    [EnumMember(Value = "pcmBig")]
    [JsonStringEnumMemberName("pcmBig")]
    PcmIntBig,

    /// <summary>
    /// PCM little-endian int
    /// </summary>
    [EnumMember(Value = "pcmLit")]
    [JsonStringEnumMemberName("pcmLit")]
    PcmIntLit,

    /// <summary>
    /// PCM float IEEE
    /// </summary>
    [EnumMember(Value = "pcmIeee")]
    [JsonStringEnumMemberName("pcmIeee")]
    PcmFloatIeee,

    /// <summary>
    /// Dolby Digital
    /// </summary>
    [EnumMember(Value = "ac-3")]
    [JsonStringEnumMemberName("ac-3")]
    Ac3,

    /// <summary>
    /// Dolby Digital with Dolby Atmos
    /// </summary>
    [EnumMember(Value = "ac-3-atmos")]
    [JsonStringEnumMemberName("ac-3-atmos")]
    Ac3Atmos,

    /// <summary>
    /// DolbyNet
    /// </summary>
    [EnumMember(Value = "dolbyNet9")]
    [JsonStringEnumMemberName("dolbyNet9")]
    Ac3Bsid9,

    /// <summary>
    /// DolbyNet
    /// </summary>
    [EnumMember(Value = "dolbyNet10")]
    [JsonStringEnumMemberName("dolbyNet10")]
    Ac3Bsid10,

    /// <summary>
    /// Dolby Digital Plus
    /// </summary>
    [EnumMember(Value = "e-ac-3")]
    [JsonStringEnumMemberName("e-ac-3")]
    Eac3,

    /// <summary>
    /// Dolby Digital Plus with Dolby Atmos
    /// </summary>
    [EnumMember(Value = "e-ac-3-atmos")]
    [JsonStringEnumMemberName("e-ac-3-atmos")]
    Eac3Atmos,

    /// <summary>
    /// Dolby TrueHD
    /// </summary>
    [EnumMember(Value = "trueHd")]
    [JsonStringEnumMemberName("trueHd")]
    Truehd,

    /// <summary>
    /// Dolby TrueHD with Dolby Atmos
    /// </summary>
    [EnumMember(Value = "trueHd-atmos")]
    [JsonStringEnumMemberName("trueHd-atmos")]
    TruehdAtmos,

    /// <summary>
    /// DTS
    /// </summary>
    [EnumMember(Value = "dts")]
    [JsonStringEnumMemberName("dts")]
    Dts,

    /// <summary>
    /// DTS:X
    /// </summary>
    [EnumMember(Value = "dts-X")]
    [JsonStringEnumMemberName("dts-X")]
    DtsX,

    /// <summary>
    /// DTS-HD MA
    /// </summary>
    [EnumMember(Value = "dts-hd-ma")]
    [JsonStringEnumMemberName("dts-hd-ma")]
    DtsHdMa,

    /// <summary>
    /// DTS Express
    /// </summary>
    [EnumMember(Value = "dts-express")]
    [JsonStringEnumMemberName("dts-express")]
    DtsExpress,

    /// <summary>
    /// DTS-HD HRA
    /// </summary>
    [EnumMember(Value = "dts-hd-hra")]
    [JsonStringEnumMemberName("dts-hd-hra")]
    DtsHdHra,

    /// <summary>
    /// DTS-HD 96/24
    /// </summary>
    [EnumMember(Value = "dts-hd")]
    [JsonStringEnumMemberName("dts-hd")]
    DtsHd,

    /// <summary>
    /// DTS-ES
    /// </summary>
    [EnumMember(Value = "dts-es")]
    [JsonStringEnumMemberName("dts-es")]
    DtsEs,

    /// <summary>
    /// Free Lossless Audio Codec
    /// </summary>
    [EnumMember(Value = "flac")]
    [JsonStringEnumMemberName("flac")]
    Flac,

    /// <summary>
    /// OPUS
    /// </summary>
    [EnumMember(Value = "opus")]
    [JsonStringEnumMemberName("opus")]
    Opus,

    /// <summary>
    /// True Audio
    /// </summary>
    [EnumMember(Value = "tta1")]
    [JsonStringEnumMemberName("tta1")]
    Tta1,

    /// <summary>
    /// VORBIS
    /// </summary>
    [EnumMember(Value = "vorbis")]
    [JsonStringEnumMemberName("vorbis")]
    Vorbis,

    /// <summary>
    /// WavPack v4
    /// </summary>
    [EnumMember(Value = "wavPack4")]
    [JsonStringEnumMemberName("wavPack4")]
    WavPack4,

    /// <summary>
    /// WavPack
    /// </summary>
    [EnumMember(Value = "wavPack")]
    [JsonStringEnumMemberName("wavPack")]
    WavPack,

    /// <summary>
    /// Waveform Audio
    /// </summary>
    [EnumMember(Value = "wave")]
    [JsonStringEnumMemberName("wave")]
    Wave,

    /// <summary>
    /// Waveform Audio
    /// </summary>
    [EnumMember(Value = "wave64")]
    [JsonStringEnumMemberName("wave64")]
    Wave64,

    /// <summary>
    /// The Real Audio
    /// </summary>
    // ReSharper disable once InconsistentNaming
    [EnumMember(Value = "real-14-4")]
    [JsonStringEnumMemberName("real-14-4")]
    Real14_4,

    /// <summary>
    /// The Real Audio
    /// </summary>
    // ReSharper disable once InconsistentNaming
    [EnumMember(Value = "real-28-8")]
    [JsonStringEnumMemberName("real-28-8")]
    Real28_8,

    /// <summary>
    /// The RealAudio Lossless (RealAudio 10)
    /// </summary>
    [EnumMember(Value = "real-10")]
    [JsonStringEnumMemberName("real-10")]
    Real10,

    /// <summary>
    /// The Real Audio
    /// </summary>
    [EnumMember(Value = "realCook")]
    [JsonStringEnumMemberName("realCook")]
    RealCook,

    /// <summary>
    /// The Real Audio
    /// </summary>
    [EnumMember(Value = "realSipr")]
    [JsonStringEnumMemberName("realSipr")]
    RealSipr,

    /// <summary>
    /// The Real Audio
    /// </summary>
    [EnumMember(Value = "realRalf")]
    [JsonStringEnumMemberName("realRalf")]
    RealRalf,

    /// <summary>
    /// The Real Audio
    /// </summary>
    [EnumMember(Value = "realAtrc")]
    [JsonStringEnumMemberName("realAtrc")]
    RealAtrc,

    /// <summary>
    /// Meridian Lossless
    /// </summary>
    [EnumMember(Value = "mlp")]
    [JsonStringEnumMemberName("mlp")]
    Mlp,

    /// <summary>
    /// Advanced Audio Coding
    /// </summary>
    [EnumMember(Value = "aac")]
    [JsonStringEnumMemberName("aac")]
    Aac,

    /// <summary>
    /// Advanced Audio Coding
    /// </summary>
    [EnumMember(Value = "aac-mpeg2-main")]
    [JsonStringEnumMemberName("aac-mpeg2-main")]
    AacMpeg2Main,

    /// <summary>
    /// Advanced Audio Coding
    /// </summary>
    [EnumMember(Value = "aac-mpeg2-lc")]
    [JsonStringEnumMemberName("aac-mpeg2-lc")]
    AacMpeg2Lc,

    /// <summary>
    /// Advanced Audio Coding
    /// </summary>
    [EnumMember(Value = "aac-mpeg2-lc-sbr")]
    [JsonStringEnumMemberName("aac-mpeg2-lc-sbr")]
    AacMpeg2LcSbr,

    /// <summary>
    /// Advanced Audio Coding
    /// </summary>
    [EnumMember(Value = "aac-mpeg2-ssr")]
    [JsonStringEnumMemberName("aac-mpeg2-ssr")]
    AacMpeg2Ssr,

    /// <summary>
    /// Advanced Audio Coding
    /// </summary>
    [EnumMember(Value = "aac-mpeg4-main")]
    [JsonStringEnumMemberName("aac-mpeg4-main")]
    AacMpeg4Main,

    /// <summary>
    /// Advanced Audio Coding
    /// </summary>
    [EnumMember(Value = "aac-mpeg4-lc")]
    [JsonStringEnumMemberName("aac-mpeg4-lc")]
    AacMpeg4Lc,

    /// <summary>
    /// Advanced Audio Coding
    /// </summary>
    [EnumMember(Value = "aac-mpeg4-lc-sbr")]
    [JsonStringEnumMemberName("aac-mpeg4-lc-sbr")]
    AacMpeg4LcSbr,

    /// <summary>
    /// Advanced Audio Coding
    /// </summary>
    [EnumMember(Value = "aac-mpeg4-lc-sbr-ps")]
    [JsonStringEnumMemberName("aac-mpeg4-lc-sbr-ps")]
    AacMpeg4LcSbrPs,

    /// <summary>
    /// Advanced Audio Coding
    /// </summary>
    [EnumMember(Value = "aac-mpeg4-ssr")]
    [JsonStringEnumMemberName("aac-mpeg4-ssr")]
    AacMpeg4Ssr,

    /// <summary>
    /// Advanced Audio Coding
    /// </summary>
    [EnumMember(Value = "aac-mpeg4-ltp")]
    [JsonStringEnumMemberName("aac-mpeg4-ltp")]
    AacMpeg4Ltp,

    /// <summary>
    /// Apple Lossless
    /// </summary>
    [EnumMember(Value = "alac")]
    [JsonStringEnumMemberName("alac")]
    Alac,

    /// <summary>
    /// Monkey's Audio
    /// </summary>
    [EnumMember(Value = "ape")]
    [JsonStringEnumMemberName("ape")]
    Ape,

    /// <summary>
    /// Windows Media Audio
    /// </summary>
    [EnumMember(Value = "wma1")]
    [JsonStringEnumMemberName("wma1")]
    Wma1,

    /// <summary>
    /// Windows Media Audio v2
    /// </summary>
    [EnumMember(Value = "wma2")]
    [JsonStringEnumMemberName("wma2")]
    Wma2,

    /// <summary>
    /// Windows Media Audio v3
    /// </summary>
    [EnumMember(Value = "wma3")]
    [JsonStringEnumMemberName("wma3")]
    Wma3,

    /// <summary>
    /// Windows Media Audio Voice
    /// </summary>
    [EnumMember(Value = "wma-voice")]
    [JsonStringEnumMemberName("wma-voice")]
    WmaVoice,

    /// <summary>
    /// Windows Media Audio Pro
    /// </summary>
    [EnumMember(Value = "wma-pro")]
    [JsonStringEnumMemberName("wma-pro")]
    WmaPro,

    /// <summary>
    /// Windows Media Audio Lossless
    /// </summary>
    [EnumMember(Value = "wma-lossless")]
    [JsonStringEnumMemberName("wma-lossless")]
    WmaLossless,

    /// <summary>
    /// Adaptive differential pulse-code modulation
    /// </summary>
    [EnumMember(Value = "adpcm")]
    [JsonStringEnumMemberName("adpcm")]
    Adpcm,

    /// <summary>
    /// Adaptive multi rate
    /// </summary>
    [EnumMember(Value = "amr")]
    [JsonStringEnumMemberName("amr")]
    Amr,

    /// <summary>
    /// Adaptive Transform Acoustic Coding (SDDS)
    /// </summary>
    [EnumMember(Value = "atrac1")]
    [JsonStringEnumMemberName("atrac1")]
    Atrac1,

    /// <summary>
    /// Adaptive Transform Acoustic Coding 3
    /// </summary>
    [EnumMember(Value = "atrac3")]
    [JsonStringEnumMemberName("atrac3")]
    Atrac3,

    /// <summary>
    /// ATRAC3plus
    /// </summary>
    [EnumMember(Value = "atrac3-plus")]
    [JsonStringEnumMemberName("atrac3-plus")]
    Atrac3Plus,

    /// <summary>
    /// ATRAC Advanced Lossless
    /// </summary>
    [EnumMember(Value = "atrac-losseless")]
    [JsonStringEnumMemberName("atrac-losseless")]
    AtracLossless,

    /// <summary>
    /// ATRAC9
    /// </summary>
    [EnumMember(Value = "atrac9")]
    [JsonStringEnumMemberName("atrac9")]
    Atrac9,

    /// <summary>
    /// Direct Stream Digital
    /// </summary>
    [EnumMember(Value = "dsd")]
    [JsonStringEnumMemberName("dsd")]
    Dsd,

    /// <summary>
    /// MAC3
    /// </summary>
    [EnumMember(Value = "mac3")]
    [JsonStringEnumMemberName("mac3")]
    Mac3,

    /// <summary>
    /// MAC6
    /// </summary>
    [EnumMember(Value = "mac6")]
    [JsonStringEnumMemberName("mac6")]
    Mac6,

    /// <summary>
    /// G.723.1
    /// </summary>
    [EnumMember(Value = "g-723-1")]
    [JsonStringEnumMemberName("g-723-1")]
    G_723_1,

    /// <summary>
    /// Truespeech
    /// </summary>
    [EnumMember(Value = "truespeech")]
    [JsonStringEnumMemberName("truespeech")]
    Truespeech,

    /// <summary>
    /// RK Audio
    /// </summary>
    [EnumMember(Value = "rk-audio")]
    [JsonStringEnumMemberName("rk-audio")]
    RkAudio,

    /// <summary>
    /// MPEG-4 Audio Lossless Coding
    /// </summary>
    [EnumMember(Value = "als")]
    [JsonStringEnumMemberName("als")]
    Als,

    /// <summary>
    /// Ligos IAC2
    /// </summary>
    [EnumMember(Value = "iac2")]
    [JsonStringEnumMemberName("iac2")]
    Iac2,

    /// <summary>
    /// MPEG-H 3D Audio
    /// </summary>
    [EnumMember(Value = "mpeg3DAudio")]
    [JsonStringEnumMemberName("mpeg3DAudio")]
    Mpeg3DAudio,

    /// <summary>
    /// Nellymoser codec
    /// </summary>
    [EnumMember(Value = "nellymoser")]
    [JsonStringEnumMemberName("nellymoser")]
    Nellymoser,

    /// <summary>
    /// The Qualcomm Pure Voice
    /// </summary>
    [EnumMember(Value = "qualcomm-pure-voice")]
    [JsonStringEnumMemberName("qualcomm-pure-voice")]
    QualcommPureVoice,

    /// <summary>
    /// QDesign Music 1
    /// </summary>
    [EnumMember(Value = "qDesignMusic1")]
    [JsonStringEnumMemberName("qDesignMusic1")]
    QDesignMusic1,

    /// <summary>
    /// QDesign Music 2
    /// </summary>
    [EnumMember(Value = "qDesignMusic2")]
    [JsonStringEnumMemberName("qDesignMusic2")]
    QDesignMusic2,

    /// <summary>
    /// Dolby AC-4
    /// </summary>
    [EnumMember(Value = "ac-4")]
    [JsonStringEnumMemberName("ac-4")]
    Ac4,

    /// <summary>
    /// Dolby E codec
    /// </summary>
    [EnumMember(Value = "dolby-e")]
    [JsonStringEnumMemberName("dolby-e")]
    DolbyE,

    /// <summary>
    /// Dolby ED2
    /// </summary>
    [EnumMember(Value = "dolby-ed2")]
    [JsonStringEnumMemberName("dolby-ed2")]
    DolbyEd2
}