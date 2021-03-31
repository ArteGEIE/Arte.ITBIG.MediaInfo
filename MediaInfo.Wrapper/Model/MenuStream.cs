﻿#region Copyright (C) 2017-2021 Yaroslav Tatarenko

// Copyright (C) 2017-2021 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2021 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MediaInfo.Model
{
  /// <summary>
  /// Describes properties of the menu
  /// </summary>
  /// <seealso cref="MediaStream" />
  [Serializable]
  [DataContract]
  public class MenuStream : MediaStream
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MenuStream"/> class.
    /// </summary>
    public MenuStream()
    {
      Chapters = new List<Chapter>();
    }

    /// <summary>
    /// Gets or sets the menu duration.
    /// </summary>
    /// <value>
    /// The menu duration.
    /// </value>
    [DataMember(Name = "duration")]
    public TimeSpan Duration { get; set; }

    /// <summary>
    /// Gets the chapters.
    /// </summary>
    /// <value>
    /// The chapters.
    /// </value>
    [DataMember(Name = "chapters")]
    public ICollection<Chapter> Chapters { get; }

    /// <inheritdoc />
    public override MediaStreamKind Kind => MediaStreamKind.Menu;

    /// <inheritdoc />
    protected override StreamKind StreamKind => StreamKind.Menu;
  }

  /// <summary>
  /// Describes properties of the menu chapter
  /// </summary>
  [Serializable]
  [DataContract]
  public sealed class Chapter
  {
    /// <summary>
    /// Gets or sets the menu position.
    /// </summary>
    /// <value>
    /// The menu position.
    /// </value>
    [DataMember(Name = "position")]
    public TimeSpan Position { get; set; }

    /// <summary>
    /// Gets or sets the menu chapter name.
    /// </summary>
    /// <value>
    /// The menu chapter name.
    /// </value>
    [DataMember(Name = "name")]
    public string Name { get; set; }
  }
}