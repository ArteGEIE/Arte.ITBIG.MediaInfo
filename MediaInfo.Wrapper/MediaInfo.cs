#region Copyright (c) MediaArea.net SARL.

/*  Copyright (c) MediaArea.net SARL. All Rights Reserved.
*
*  Use of this source code is governed by a BSD-style license that can
*  be found in the License.html file in the root of the source tree.
*/

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//
// Microsoft Visual C# wrapper for MediaInfo Library
// See MediaInfo.h for help
//
// To make it working, you must put MediaInfo.Dll
// in the executable folder
//
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
#endregion

using System;
using System.IO;
using System.Runtime.InteropServices;

#pragma warning disable 1591 // Disable XML documentation warnings

namespace MediaInfo
{
  public enum InfoFileOptions
  {
    Nothing = 0x00,
    NoRecursive = 0x01,
    CloseAll = 0x02,
    Max = 0x04
  };

  /// <summary>
  /// Describes kind of streams
  /// </summary>
  public enum StreamKind
  {
    /// <summary>
    /// The general (container, disk info)
    /// </summary>
    General,

    /// <summary>
    /// The video
    /// </summary>
    Video,

    /// <summary>
    /// The audio
    /// </summary>
    Audio,

    /// <summary>
    /// The subtitles and text information
    /// </summary>
    Text,

    /// <summary>
    /// The other (chapters)
    /// </summary>
    Other,

    /// <summary>
    /// The image
    /// </summary>
    Image,

    /// <summary>
    /// The menu
    /// </summary>
    Menu,
  }

  public enum InfoKind
  {
    Name,
    Text,
    Measure,
    Options,
    NameText,
    MeasureText,
    Info,
    HowTo
  }

  public enum InfoOptions
  {
    ShowInInform,
    Support,
    ShowInSupported,
    TypeOfValue
  }

  /// <summary>
  /// Describes low-level functions to access to media information
  /// </summary>
  /// <seealso cref="IDisposable" />
  public class MediaInfo : IDisposable
  {
#if (NET40 || NET45)
    private const string MediaInfoFileName = "MediaInfo.dll";
    private IntPtr _module;
#endif
    private readonly bool _mustUseAnsi;

    /// <summary>
    /// Initializes a new instance of the <see cref="MediaInfo"/> class.
    /// </summary>
#if (NET40 || NET45)
    public MediaInfo() :
      this(Environment.Is64BitProcess ? @".\x64" : @".\x86")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MediaInfo"/> class.
    /// </summary>
    /// <param name="pathToDll">The path to mediainfo.dll.</param>
    public MediaInfo(string pathToDll)
    {
      _module = NativeMethods.LoadLibraryEx(Path.Combine(pathToDll, MediaInfoFileName), IntPtr.Zero, NativeMethods.LoadLibraryFlags.DEFAULT);
      try
      {
        Handle = NativeMethods.MediaInfo_New();
      }
      catch
      {
        Handle = IntPtr.Zero;
      }

      _mustUseAnsi = Environment.OSVersion.ToString().IndexOf("Windows", StringComparison.OrdinalIgnoreCase) == -1;
    }
#else
    public MediaInfo()
    {
      try
      {
        Handle = NativeMethods.MediaInfo_New();
      }
      catch
      {
        Handle = IntPtr.Zero;
      }

      _mustUseAnsi = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    }
#endif

    /// <summary>
    /// Finalizes an instance of the <see cref="MediaInfo"/> class.
    /// </summary>
    ~MediaInfo()
    {
      Dispose(false);
    }

    /// <summary>
    /// Opens the specified file name.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <returns>Return internal handle to access to low-level functions.</returns>
    public IntPtr Open(string fileName)
    {
      if (Handle == IntPtr.Zero)
      {
        return IntPtr.Zero;
      }

      return _mustUseAnsi ?
              NativeMethods.MediaInfoA_Open(Handle, fileName) :
              NativeMethods.MediaInfo_Open(Handle, fileName);
    }

    /// <summary>
    /// Gets the library handle.
    /// </summary>
    /// <value>The library handle.</value>
    internal IntPtr Handle { get; private set; }

    /// <summary>
    /// Opens the buffer initialize.
    /// </summary>
    /// <param name="fileSize">Size of the file.</param>
    /// <param name="fileOffset">The file offset.</param>
    /// <returns></returns>
    public IntPtr OpenBufferInit(long fileSize, long fileOffset)
    {
      return Handle == IntPtr.Zero ? IntPtr.Zero : NativeMethods.MediaInfo_Open_Buffer_Init(Handle, fileSize, fileOffset);
    }

    /// <summary>
    /// Opens the buffer continue.
    /// </summary>
    /// <param name="buffer">The buffer.</param>
    /// <param name="bufferSize">Size of the buffer.</param>
    /// <returns></returns>
    public IntPtr OpenBufferContinue(IntPtr buffer, IntPtr bufferSize)
    {
      return Handle == IntPtr.Zero ? IntPtr.Zero : NativeMethods.MediaInfo_Open_Buffer_Continue(Handle, buffer, bufferSize);
    }

    /// <summary>
    /// Opens the buffer continue go to get.
    /// </summary>
    /// <returns></returns>
    public long OpenBufferContinueGoToGet()
    {
      return Handle == IntPtr.Zero ? 0 : NativeMethods.MediaInfo_Open_Buffer_Continue_GoTo_Get(Handle);
    }

    /// <summary>
    /// Opens the buffer finalize.
    /// </summary>
    /// <returns></returns>
    public IntPtr OpenBufferFinalize()
    {
      return Handle == IntPtr.Zero ? IntPtr.Zero : NativeMethods.MediaInfo_Open_Buffer_Finalize(Handle);
    }

    /// <summary>
    /// Closes this instance.
    /// </summary>
    public void Close()
    {
      if (Handle != IntPtr.Zero)
      {
        NativeMethods.MediaInfo_Delete(Handle);
        Handle = IntPtr.Zero;
      }
    }

    /// <summary>
    /// Informs media stream data.
    /// </summary>
    /// <returns></returns>
    public string Inform()
    {
      if (Handle == IntPtr.Zero)
      {
        return "Unable to load MediaInfo library";
      }

      return _mustUseAnsi ?
               Marshal.PtrToStringAnsi(NativeMethods.MediaInfoA_Inform(Handle, IntPtr.Zero)) :
               Marshal.PtrToStringUni(NativeMethods.MediaInfo_Inform(Handle, IntPtr.Zero));
    }

    /// <summary>
    /// Gets property value by specified stream kind and name.
    /// </summary>
    /// <param name="streamKind">Kind of the stream.</param>
    /// <param name="streamNumber">The stream number.</param>
    /// <param name="parameter">The parameter.</param>
    /// <param name="kindOfInfo">The kind of information.</param>
    /// <param name="kindOfSearch">The kind of search.</param>
    /// <returns>Returns property value</returns>
    public string Get(StreamKind streamKind, int streamNumber, string parameter, InfoKind kindOfInfo, InfoKind kindOfSearch)
    {
      if (Handle == IntPtr.Zero)
      {
        return "Unable to load MediaInfo library";
      }

      return _mustUseAnsi ?
        Marshal.PtrToStringAnsi(
          NativeMethods.MediaInfoA_Get(
            Handle,
            (IntPtr)streamKind,
            (IntPtr)streamNumber,
            parameter,
            (IntPtr)kindOfInfo,
            (IntPtr)kindOfSearch)) :
        Marshal.PtrToStringUni(
          NativeMethods.MediaInfo_Get(
            Handle,
            (IntPtr)streamKind,
            (IntPtr)streamNumber,
            parameter,
            (IntPtr)kindOfInfo,
            (IntPtr)kindOfSearch));
    }

    public string Get(StreamKind streamKind, int streamNumber, int parameter, InfoKind kindOfInfo)
    {
      if (Handle == IntPtr.Zero)
      {
        return "Unable to load MediaInfo library";
      }

      return _mustUseAnsi ?
        Marshal.PtrToStringAnsi(NativeMethods.MediaInfoA_GetI(Handle, (IntPtr)streamKind, (IntPtr)streamNumber, (IntPtr)parameter, (IntPtr)kindOfInfo)) :
        Marshal.PtrToStringUni(NativeMethods.MediaInfo_GetI(Handle, (IntPtr)streamKind, (IntPtr)streamNumber, (IntPtr)parameter, (IntPtr)kindOfInfo));
    }

    /// <summary>
    /// Sets value to specified option name.
    /// </summary>
    /// <param name="option">The option name.</param>
    /// <param name="value">The option value.</param>
    /// <returns></returns>
    public string Option(string option, string value)
    {
      if (Handle == IntPtr.Zero)
      {
        return "Unable to load MediaInfo library";
      }

      return _mustUseAnsi ?
               Marshal.PtrToStringAnsi(NativeMethods.MediaInfoA_Option(Handle, option, value)) :
               Marshal.PtrToStringUni(NativeMethods.MediaInfo_Option(Handle, option, value));
    }

    /// <summary>
    /// Gets the state.
    /// </summary>
    /// <returns></returns>
    public IntPtr StateGet()
    {
      return Handle == IntPtr.Zero ? IntPtr.Zero : NativeMethods.MediaInfo_State_Get(Handle);
    }

    /// <summary>
    /// Gets count items of the specified stream.
    /// </summary>
    /// <param name="streamKind">Kind of the stream.</param>
    /// <param name="streamNumber">The stream number.</param>
    /// <returns></returns>
    public int CountGet(StreamKind streamKind, int streamNumber)
    {
      return Handle == IntPtr.Zero ? 0 : (int)NativeMethods.MediaInfo_Count_Get(Handle, (IntPtr)streamKind, (IntPtr)streamNumber);
    }

    //Default values, if you know how to set default values in C#, say me
    public string Get(StreamKind streamKind, int streamNumber, string parameter, InfoKind kindOfInfo)
    {
      return Get(streamKind, streamNumber, parameter, kindOfInfo, InfoKind.Name);
    }

    /// <summary>
    /// Gets the specified parameter value in the stream by parameter name.
    /// </summary>
    /// <param name="streamKind">Kind of the stream.</param>
    /// <param name="streamNumber">The stream number.</param>
    /// <param name="parameter">The parameter.</param>
    /// <returns></returns>
    public string Get(StreamKind streamKind, int streamNumber, string parameter)
    {
      return Get(streamKind, streamNumber, parameter, InfoKind.Text, InfoKind.Name);
    }

    /// <summary>
    /// Gets the specified parameter value in the stream by parameter index.
    /// </summary>
    /// <param name="streamKind">Kind of the stream.</param>
    /// <param name="streamNumber">The stream number.</param>
    /// <param name="parameter">The parameter.</param>
    /// <returns></returns>
    public string Get(StreamKind streamKind, int streamNumber, int parameter)
    {
      return Get(streamKind, streamNumber, parameter, InfoKind.Text);
    }

    /// <summary>
    /// Gets options value by the specified option name.
    /// </summary>
    /// <param name="option">The option.</param>
    /// <returns></returns>
    public string Option(string option)
    {
      return Option(option, string.Empty);
    }

    /// <summary>
    /// Gets count of specified kind of streams.
    /// </summary>
    /// <param name="streamKind">Kind of the streams.</param>
    /// <returns></returns>
    public int CountGet(StreamKind streamKind)
    {
      return CountGet(streamKind, -1);
    }

    /// <summary>
    /// Releases unmanaged and - optionally - managed resources.
    /// </summary>
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    // ReSharper disable once UnusedParameter.Local
    private void Dispose(bool disposing)
    {
      Close();
#if (NET40 || NET45)
      if (_module != IntPtr.Zero)
      {
        NativeMethods.FreeLibrary(_module);
        _module = IntPtr.Zero;
      }
#endif
    }
  }

  /// <summary>
  /// Describes low-level function to access to mediaInfo lists
  /// </summary>
  /// <seealso cref="IDisposable" />
  public class MediaInfoList : IDisposable
  {
    private readonly bool _useAnsiStrings;
    private IntPtr _handle;

    /// <summary>
    /// Initializes a new instance of the <see cref="MediaInfoList"/> class.
    /// </summary>
    public MediaInfoList(bool useAnsiStrings)
    {
      _useAnsiStrings = useAnsiStrings;
      _handle = NativeMethods.MediaInfoList_New();
    }

    /// <summary>
    /// Finalizes an instance of the <see cref="MediaInfoList"/> class.
    /// </summary>
    ~MediaInfoList()
    {
      Dispose(false);
    }

    /// <summary>
    /// Opens the specified file name.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <param name="options">The options.</param>
    /// <returns></returns>
    public int Open(string fileName, InfoFileOptions options)
    {
      return _useAnsiStrings ?
        (int)NativeMethods.MediaInfoListA_Open(_handle, fileName, (IntPtr)options) :
        (int)NativeMethods.MediaInfoList_Open(_handle, fileName, (IntPtr)options);
    }

    /// <summary>
    /// Closes the specified file position.
    /// </summary>
    /// <param name="filePos">The file position.</param>
    public void Close(int filePos)
    {
      NativeMethods.MediaInfoList_Close(_handle, (IntPtr)filePos);
    }

    /// <summary>
    /// Informs the specified file position.
    /// </summary>
    /// <param name="filePos">The file position.</param>
    /// <returns></returns>
    public string Inform(int filePos)
    {
      return _useAnsiStrings ?
               Marshal.PtrToStringAnsi(NativeMethods.MediaInfoListA_Inform(_handle, (IntPtr)filePos, IntPtr.Zero)) :
               Marshal.PtrToStringUni(NativeMethods.MediaInfoList_Inform(_handle, (IntPtr)filePos, IntPtr.Zero));
    }

    /// <summary>
    /// Gets the property value in specified file position by stream and property name.
    /// </summary>
    /// <param name="filePos">The file position.</param>
    /// <param name="streamKind">Kind of the stream.</param>
    /// <param name="streamNumber">The stream number.</param>
    /// <param name="parameter">The property name.</param>
    /// <param name="kindOfInfo">The kind of information.</param>
    /// <param name="kindOfSearch">The kind of search.</param>
    /// <returns></returns>
    public string Get(int filePos, StreamKind streamKind, int streamNumber, string parameter, InfoKind kindOfInfo, InfoKind kindOfSearch)
    {
      return _useAnsiStrings ?
               Marshal.PtrToStringAnsi(NativeMethods.MediaInfoListA_Get(_handle, (IntPtr)filePos, (IntPtr)streamKind, (IntPtr)streamNumber, parameter, (IntPtr)kindOfInfo, (IntPtr)kindOfSearch)) :
               Marshal.PtrToStringUni(NativeMethods.MediaInfoList_Get(_handle, (IntPtr)filePos, (IntPtr)streamKind, (IntPtr)streamNumber, parameter, (IntPtr)kindOfInfo, (IntPtr)kindOfSearch));
    }

    /// <summary>
    /// Gets the property value in specified file position by stream and property index.
    /// </summary>
    /// <param name="filePos">The file position.</param>
    /// <param name="streamKind">Kind of the stream.</param>
    /// <param name="streamNumber">The stream number.</param>
    /// <param name="parameter">The property index.</param>
    /// <param name="kindOfInfo">The kind of information.</param>
    /// <returns></returns>
    public string Get(int filePos, StreamKind streamKind, int streamNumber, int parameter, InfoKind kindOfInfo)
    {
      return _useAnsiStrings ?
               Marshal.PtrToStringAnsi(NativeMethods.MediaInfoListA_GetI(_handle, (IntPtr)filePos, (IntPtr)streamKind, (IntPtr)streamNumber, (IntPtr)parameter, (IntPtr)kindOfInfo)) :
               Marshal.PtrToStringUni(NativeMethods.MediaInfoList_GetI(_handle, (IntPtr)filePos, (IntPtr)streamKind, (IntPtr)streamNumber, (IntPtr)parameter, (IntPtr)kindOfInfo));
    }

    /// <summary>
    /// Sets options value by the specified option name.
    /// </summary>
    /// <param name="option">The option name.</param>
    /// <param name="value">The option value.</param>
    /// <returns></returns>
    public string Option(string option, string value)
    {
      return _useAnsiStrings ?
               Marshal.PtrToStringAnsi(NativeMethods.MediaInfoListA_Option(_handle, option, value)) :
               Marshal.PtrToStringUni(NativeMethods.MediaInfoList_Option(_handle, option, value));
    }

    /// <summary>
    /// Gets current state.
    /// </summary>
    /// <returns></returns>
    public int StateGet()
    {
      return (int)NativeMethods.MediaInfoList_State_Get(_handle);
    }

    /// <summary>
    /// Gets count of items in file position and stream.
    /// </summary>
    /// <param name="filePos">The file position.</param>
    /// <param name="streamKind">Kind of the stream.</param>
    /// <param name="streamNumber">The stream number.</param>
    /// <returns></returns>
    public int CountGet(int filePos, StreamKind streamKind, int streamNumber)
    {
      return (int)NativeMethods.MediaInfoList_Count_Get(_handle, (IntPtr)filePos, (IntPtr)streamKind, (IntPtr)streamNumber);
    }

    /// <summary>
    /// Opens the specified file name.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    public void Open(string fileName)
    {
      Open(fileName, 0);
    }

    /// <summary>
    /// Closes this instance.
    /// </summary>
    public void Close()
    {
      Close(-1);
    }

    /// <summary>
    /// Gets the specified file position.
    /// </summary>
    /// <param name="filePos">The file position.</param>
    /// <param name="streamKind">Kind of the stream.</param>
    /// <param name="streamNumber">The stream number.</param>
    /// <param name="parameter">The parameter.</param>
    /// <param name="kindOfInfo">The kind of information.</param>
    /// <returns></returns>
    public string Get(int filePos, StreamKind streamKind, int streamNumber, string parameter, InfoKind kindOfInfo)
    {
      return Get(filePos, streamKind, streamNumber, parameter, kindOfInfo, InfoKind.Name);
    }

    /// <summary>
    /// Gets the specified file position.
    /// </summary>
    /// <param name="filePos">The file position.</param>
    /// <param name="streamKind">Kind of the stream.</param>
    /// <param name="streamNumber">The stream number.</param>
    /// <param name="parameter">The parameter.</param>
    /// <returns></returns>
    public string Get(int filePos, StreamKind streamKind, int streamNumber, string parameter)
    {
      return Get(filePos, streamKind, streamNumber, parameter, InfoKind.Text, InfoKind.Name);
    }

    /// <summary>
    /// Gets the specified file position.
    /// </summary>
    /// <param name="filePos">The file position.</param>
    /// <param name="streamKind">Kind of the stream.</param>
    /// <param name="streamNumber">The stream number.</param>
    /// <param name="parameter">The parameter.</param>
    /// <returns></returns>
    public string Get(int filePos, StreamKind streamKind, int streamNumber, int parameter)
    {
      return Get(filePos, streamKind, streamNumber, parameter, InfoKind.Text);
    }

    /// <summary>
    /// Gets options value by the specified option name.
    /// </summary>
    /// <param name="option">The option name.</param>
    /// <returns></returns>
    public string Option(string option)
    {
      return Option(option, string.Empty);
    }

    /// <summary>
    /// Gets count of specified kind of stream in th file position.
    /// </summary>
    /// <param name="filePos">The file position.</param>
    /// <param name="streamKind">Kind of the streams.</param>
    /// <returns></returns>
    public int CountGet(int filePos, StreamKind streamKind)
    {
      return CountGet(filePos, streamKind, -1);
    }

    /// <summary>
    /// Releases unmanaged and - optionally - managed resources.
    /// </summary>
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    // ReSharper disable once UnusedParameter.Local
    private void Dispose(bool disposing)
    {
      if (_handle != IntPtr.Zero)
      {
        NativeMethods.MediaInfoList_Delete(_handle);
        _handle = IntPtr.Zero;
      }
    }
  }
}