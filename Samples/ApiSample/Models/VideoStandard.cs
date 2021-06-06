﻿#region Copyright (C) 2017-2021 Yaroslav Tatarenko

// Copyright (C) 2017-2021 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2021 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

using System.Runtime.Serialization;

namespace ApiSample.Models
{
    /// <summary>
    /// Describes video standards
    /// </summary>
    [DataContract]
    public enum VideoStandard
    {
        /// <summary>
        /// NTSC standard
        /// </summary>
        [EnumMember(Value = "ntsc")]
        NTSC,

        /// <summary>
        /// PAL standard
        /// </summary>
        [EnumMember(Value = "pal")]
        PAL
    }
}
