# Arte.ITBIG.MediaInfo

Arte.ITBIG.MediaInfo is a fork of [MP-MediaInfo](https://github.com/yartat/MP-MediaInfo).

It is .NET wrapper for [MediaArea MediaInfo](https://github.com/MediaArea/MediaInfo) and use native packages [![NuGet Badge](https://img.shields.io/nuget/v/MediaInfo.Core.Native?label=MediaInfo.Core.Native)](https://www.nuget.org/packages/MediaInfo.Core.Native).


## Features

* Wraps the MediaInfo library
* Provides properties for almost all information  available using the MediaInfo library
* Targets .NET 10

## Available packages

| Framework | Package |
|-----------|---------|
| .NET 10.0 | [![NuGet Badge](https://img.shields.io/badge/package-Arte.ITBIG.MediaInfo-blue)](https://www.github.com/ArteGEIE/Arte.ITBIG.MediaInfo/pkg/nuget/Arte.ITBIG.MediaInfo) |

## Installation

There are a package for .NET Core and it's designed for ASP.NET Core services only.

### .NET Core

```Shell{:copy}
dotnet add package Arte.ITBIG.MediaInfo --version 26.0.1
```

## Usage

### Basic Setup

Add to usings:

```csharp
using MediaInfo;
```

Instantiate a `MediaInfoWrapper` with the path to your media file:

```csharp
var media = new MediaInfoWrapper("path/to/media/file.mp4");
```

### Checking Analysis Success

Always verify the file was successfully analyzed:

```csharp
if (media.Success)
{
    // File analyzed successfully
}
else
{
    // Handle analysis failure
    Console.WriteLine("Failed to analyze media file");
}
```

### General Information

Access basic media information:

```csharp
var containerCodec = media.Codec;               // e.g., "MPEG-4"
var containerFormat = media.Format;             // e.g., "MP4"
var duration = media.Duration;                  // Duration in milliseconds
var isMediaBluRay = media.IsBluRay;             // media is Blu-ray or not
var isMediaDvd = media.IsDvd;                   // media is DVD or not
var isMediaStreamable = media.IsStreamable;	    // media is streamable or not

```

### Video Stream Analysis

Extract detailed video information:

```csharp
if (media.HasVideo)
{
    var videoStream = media.VideoStreams.FirstOrDefault();
    if (videoStream != null)
    {
        var width = videoStream.Width;                          // Resolution width
        var height = videoStream.Height;                        // Resolution height
        var codec = videoStream.Codec;                          // e.g., AVC, HEVC, VP9, etc.
        var frameRate = videoStream.FrameRate;                  // Frames per second
        var frameRateMode = videoStream.FrameRateMode;          // e.g., CFR, VFR
        var bitRate = videoStream.Bitrate;                      // Video stream bitrate
        var standard = videoStream.Standard;                    // e.g., NTSC, PAL
        var aspectRatio = videoStream.AspectRatio;              // e.g., HighEndDataGraphics, Square, etc.
        var chromaSubSampling = videoStream.SubSampling;        // e.g., Sampling420, Sampling422, Sampling444
        var colorSpace = videoStream.ColorSpace;                // e.g., BT2020, BT709, NTSC, etc.
        var hdrFormat = videoStream.Hdr;                        // e.g., HDR10, DolbyVision, HLG, etc.
        var isInterlaced = videoStream.IsInterlaced;            // true if video is interlaced
        var stereoscopic = videoStream.Stereoscopic;            // e.g., Mono, Stereo, SideBySideLeft, TopBottomRight, etc.
    }
}
```

### Audio Stream Analysis

Access audio track information:

```csharp
foreach (var audioStream in media.AudioStreams)
{
    var language = audioStream.Language;                      // ISO 639-2 language code
    var codec = audioStream.Codec;                            // e.g., AAC, AC-3, DTS, etc.
    var bitRate = audioStream.Bitrate;                        // Audio bitrate
    var channelCount = audioStream.Channel;                   // Number of audio channels
    var channelsFriendly = audioStream.AudioChannelsFriendly; // e.g., "5.1", "Stereo"
    var samplingRate = audioStream.SamplingRate;              // Sample rate in Hz
    var bitDepth = audioStream.BitDepth;                      // Bits per sample
    var bitrateMode = audioStream.BitrateMode;                // CBR, VBR, etc.
    var name = audioStream.Name;                              // Track name if available
}
```

### Subtitle Stream Analysis

Retrieve subtitle information:

```csharp
foreach (var subtitleStream in media.SubtitleStreams)
{
    var codec = subtitleStream.Codec;              // e.g., "PGS", "ASS"
    var language = subtitleStream.Language;        // ISO 639-2 language code
    var name = subtitleStream.Name;                // Subtitle track name
}
```

### Audio and Video Tags

Extract metadata:

```csharp
var audioTags = media.AudioStreams.Select(x => x.Tags);  // Audio metadata (album, artist, etc.)
var videoTags = media.VideoStreams.Select(x => x.Tags);  // Video metadata (title, description, etc.)
var generalInfo = media.Tags;                            // File-level metadata

foreach (var audioTag in audioTags)
{
    var artist = audioTag.Performer;
    var album = audioTag.Album;
    var title = audioTag.Title;
}
```

### Chapter Information

Access chapter/menu information:

```csharp
foreach (var chapter in media.ChapterStreams)
{
    var startTime = chapter.Offset;  // Chapter start timestamp
    // Chapter stream information available
}
```

### Using a Logger

Optionally provide a logger to track analysis:

```csharp
public class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine(message);
}

var logger = new ConsoleLogger();
var media = new MediaInfoWrapper("path/to/file.mp4", logger);
```

## Supported Formats

MP-MediaInfo supports analysis of virtually all media formats supported by the underlying MediaInfo library, including:

**Video Formats**: MP4, MKV, AVI, MOV, FLV, WebM, WMV, 3GP, and many more

**Audio Codecs**: H.264/AVC, H.265/HEVC, MPEG-4, VP8, VP9, AV1, Theora, and others

**Audio Formats**: MP3, AAC, FLAC, Opus, Vorbis, AC-3, DTS, TrueHD, Atmos, and more

**Subtitle Formats**: PGS, ASS/SSA, SRT, SUBRIP, DVB, and other subtitle types

For a complete and detailed list, refer to the [MediaInfo documentation](https://github.com/MediaArea/MediaInfo).

## Advanced Usage

### Error Handling

Handle potential errors gracefully:

```csharp
try
{
    var media = new MediaInfoWrapper(filePath);

    if (!media.Success)
    {
        Console.WriteLine("Analysis was not successful");
        return;
    }

    // Process media information
}
catch (FileNotFoundException)
{
    Console.WriteLine("Media file not found");
}
catch (Exception ex)
{
    Console.WriteLine($"Error analyzing media: {ex.Message}");
}
```

### Batch Processing Multiple Files

Analyze multiple files efficiently:

```csharp
var mediaFiles = Directory.GetFiles("mediaFolder", "*.mp4");

foreach (var file in mediaFiles)
{
    try
    {
        var media = new MediaInfoWrapper(file);
        if (media.Success)
        {
            Console.WriteLine($"{Path.GetFileName(file)}: {media.Format}");
            // Process each file
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error processing {file}: {ex.Message}");
    }
}
```

### Checking Specific Media Characteristics

```csharp
var media = new MediaInfoWrapper(filePath);

// Check if file has video
if (media.HasVideo)
{
    var videoStream = media.VideoStreams.FirstOrDefault();
    if (videoStream?.Hdr != null)
    {
        Console.WriteLine($"HDR Format: {videoStream.Hdr}");
    }
}

// Check number of audio tracks
Console.WriteLine($"Audio tracks: {media.AudioStreams.Count}");

// Find specific audio Dolby Digital codec
var ac3Tracks = media.AudioStreams
    .Where(x => x.Codec == AudioCodec.Ac3)
    .ToList();
```

## Troubleshooting

### Analysis Returns False (media.Success == false)

- Verify the file path is correct and the file exists
- Ensure the file is not corrupted
- Check that the media format is supported
- On Linux/macOS, verify all dependencies (libzen, zlib) are installed
- Try enabling logging to see detailed error messages

### Missing Native Libraries

**Windows**: The native MediaInfo libraries are included in the NuGet package. No additional installation needed.

**Linux/macOS**: Install system dependencies as described in the [Dependencies](#dependencies) section.

## Demo application

ASP.NET Core demo application is [available](https://github.com/yartat/MP-MediaInfo/tree/master/Samples/ApiSample) which shows the usage of the package, serialization and running from the docker container. Code from this demo should not be used in production code, the code is merely to demonstrate the usage of this package.

## Dependencies

Make sure that the following dependencies are installed in the operating system before starting the project

* [libzen](https://github.com/MediaArea/ZenLib)
* [zlib](https://zlib.net)

.NET Core package supports next operating systems

| Operation system | Version |
|-----------|---------|
| [Alpine](#alpine) | 3.17, 3.18, 3.19 and 3.20 |
| [MacOS](#macos) | 10.15 and above |
| [Ubuntu](#ubuntu) | 16.04, 18.04, 20.04, 21.04, 22.04, 24.04 and 25.10 |
| [CenOS](#centos) | 8 and above |
| [Fedora](#fedora) | 32 and above |
| [OpenSUSE](#opensuse) | 15.4 and above |
| [RedHat](#redhat) | 7 and above |
| [Debian](#debian) | 9 and above |
| [Kali Linux](#kali-linux) | |
| [Windows](#windows) | 7 and above |
| [Docker](#docker) | buster |

### Alpine

```sh{:copy}
apk update
apk add --no-cache libmms-dev libssh openssl curl-dev ca-certificates
```

### MacOS

Some dependencies are available with MacPorts. To install MacPorts: <https://guide.macports.org/#installing>

```sh{:copy}
port install zlib curl zenlib
```

### Ubuntu

```Shell{:copy}
sudo apt-get update
sudo apt-get install libzen0v5 libmms0 zlib1g zlibc libnghttp2-14 librtmp1 curl libcurl4-gnutls-dev libglib2.0-dev
```

### CentOS

#### CentOS 8

```Shell{:copy}
sudo rpm -ivh https://dl.fedoraproject.org/pub/epel/epel-release-latest-8.noarch.rpm
sudo yum -y update
sudo yum -y install zlib curl libzen bzip2 libcurl
sudo rpm -ivh https://www.rpmfind.net/linux/epel/8/Everything/x86_64/Packages/l/libmms-0.6.4-24.el8.x86_64.rpm
```

#### CentOS 9

```Shell{:copy}
sudo rpm -ivh https://dl.fedoraproject.org/pub/epel/epel-release-latest-9.noarch.rpm
sudo yum -y update
sudo yum -y install zlib curl libzen bzip2 libcurl libmms
sudo rpm -ivh https://www.rpmfind.net/linux/epel/9/Everything/x86_64/Packages/l/libmms-0.6.4-24.el9.x86_64.rpm
```

#### CentOS 10

```Shell{:copy}
sudo rpm -ivh https://dl.fedoraproject.org/pub/epel/epel-release-latest-10.noarch.rpm
sudo yum -y update
sudo yum -y install zlib curl libzen bzip2 libcurl libmms
```

### Fedora

```Shell{:copy}
sudo dnf update
sudo dnf -y install zlib curl libzen openssl libmms
```

### OpenSUSE

```Shell{:copy}
sudo zypper refresh
sudo zypper update -y
sudo zypper install -y zlib curl libmms0 openssl libnghttp2-14
```

### RedHat

#### RedHat 7

#### RedHat 8

```Shell{:copy}
sudo rpm -ivh https://dl.fedoraproject.org/pub/epel/epel-release-latest-8.noarch.rpm
sudo yum -y update
sudo yum -y install zlib curl libzen bzip2 libcurl
sudo rpm -ivh https://www.rpmfind.net/linux/epel/8/Everything/x86_64/Packages/l/libmms-0.6.4-24.el8.x86_64.rpm
```

#### RedHat 9

```Shell{:copy}
sudo rpm -ivh https://dl.fedoraproject.org/pub/epel/epel-release-latest-9.noarch.rpm
sudo yum -y update
sudo yum -y install zlib curl libzen bzip2 libcurl
sudo rpm -ivh https://www.rpmfind.net/linux/epel/9/Everything/x86_64/Packages/l/libmms-0.6.4-24.el9.x86_64.rpm
```

#### RedHat 10

```Shell{:copy}
sudo rpm -ivh https://dl.fedoraproject.org/pub/epel/epel-release-latest-10.noarch.rpm
sudo yum -y update
sudo yum -y install zlib curl libzen bzip2 libcurl libmms
```

### Debian

```Shell{:copy}
sudo apt-get update
sudo apt-get install libzen0v5 libmms0 openssl zlib1g zlibc libnghttp2-14 librtmp1 curl libcurl4-gnutls-dev libglib2.0
```

### Kali Linux

```Shell{:copy}
sudo apt update
sudo apt install -y zlib1g-dev curl libssh-4 libmms-dev openssl libzen-dev openssl libnghttp2-14 librtmp1 libcurl4-gnutls-dev
```

### Windows

Windows package contains all dependencies and does not required any actions.

### ArchLinux

```Shell{:copy}
sudo pacman -Syu
sudo pacman -S libcurl-gnutls libzen libmms libssh librtmp0
```

### Docker

#### .NET 10.0

```Dockerfile{:copy}
FROM mcr.microsoft.com/dotnet/aspnet:10.0
RUN apt-get update && apt-get install -y libzen0v5 libmms0 openssl zlib1g zlibc libnghttp2-14 librtmp1 curl libcurl4-gnutls-dev libglib2.0
```
