#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

using MediaInfo.Model;

namespace MediaInfo.Builder
{
  /// <summary>
  /// Defines an interface for building and returning a parsed media stream of a specified type.
  /// </summary>
  /// <typeparam name="TStream">The type of media stream to be built. Must inherit from MediaStream.</typeparam>
  internal interface IMediaBuilder<out TStream> where TStream : MediaStream
  {
    /// <summary>
    /// Builds and returns a configured stream instance of type <typeparamref name="TStream"/>.
    /// </summary>
    /// <returns>A stream instance of type <typeparamref name="TStream"/> that has been configured according to the builder's settings.</returns>
    TStream Build();
  }
}