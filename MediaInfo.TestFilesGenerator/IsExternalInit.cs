#region Copyright (C) 2017-2026 Yaroslav Tatarenko

// Copyright (C) 2017-2026 Yaroslav Tatarenko
// This product uses MediaInfo library, Copyright (c) 2002-2026 MediaArea.net SARL. 
// https://mediaarea.net

#endregion

#if NETFRAMEWORK
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.CompilerServices;

/// <summary>
///     Reserved to be used by the compiler for tracking metadata.
///     This class should not be used by developers in source code.
/// </summary>
/// <remarks>
///     This definition is provided by the <i>IsExternalInit</i> NuGet package (https://www.nuget.org/packages/IsExternalInit).
///     Please see https://github.com/manuelroemer/IsExternalInit for more information.
/// </remarks>
[ExcludeFromCodeCoverage, DebuggerNonUserCode]
internal static class IsExternalInit
{
}

#endif