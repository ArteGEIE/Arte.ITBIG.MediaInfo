#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

using Mapster;
using MediaInfo;
using System;

namespace ApiSample.Infrastructure;

internal class MapperRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<MediaInfoWrapper, Models.MediaInfo>()
            .Map(dest => dest.Duration, src => TimeSpan.FromSeconds(src.Duration));
    }
}
