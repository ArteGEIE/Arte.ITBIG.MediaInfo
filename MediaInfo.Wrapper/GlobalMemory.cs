#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

using System;
using System.Runtime.InteropServices;

namespace MediaInfo
{
  /// <summary>
  /// Represents a global memory block that can be used to store ANSI encoded strings.
  /// </summary>
  /// <remarks>
  /// This class is a wrapper around a global memory block allocated using <see cref="Marshal.StringToHGlobalAnsi"/> and is designed to be used with the MediaInfo library for handling string data.
  /// It implements the <see cref="SafeHandle"/> pattern to ensure that the allocated memory is properly released when no longer needed.
  /// </remarks>
  /// <seealso cref="SafeHandle" />
  public class GlobalMemory : SafeHandle
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalMemory"/> class with the specified handle.
    /// </summary>
    /// <param name="handle">The handle to the global memory block.</param>
    public GlobalMemory(IntPtr handle)
        : base(handle, true)
    {
    }

    /// <summary>
    /// Converts the string to global memory block with ANSI encoding.
    /// </summary>
    /// <param name="source">The source string.</param>
    /// <returns>A <see cref="GlobalMemory"/> instance containing the ANSI encoded string.</returns>
    public static GlobalMemory StringToGlobalAnsi(string source) =>
      new(Marshal.StringToHGlobalAnsi(source));

    /// <summary>
    /// When overridden in a derived class, executes the code required to free the handle.
    /// </summary>
    /// <returns>True if the handle is released successfully; otherwise, false.</returns>
    protected override bool ReleaseHandle()
    {
      if (handle != IntPtr.Zero)
      {
        Marshal.FreeHGlobal(handle);
        handle = IntPtr.Zero;
      }

      return true;
    }

    /// <summary>
    /// When overridden in a derived class, gets a value indicating whether the handle is invalid.
    /// </summary>
    public override bool IsInvalid => handle == IntPtr.Zero;
  }
}
