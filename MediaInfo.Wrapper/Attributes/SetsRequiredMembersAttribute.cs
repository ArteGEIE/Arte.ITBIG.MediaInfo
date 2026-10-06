#if NET7_0_OR_GREATER
#else

namespace System.Diagnostics.CodeAnalysis;

/// <summary>
/// Specifies that a method sets all required members for a class type.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Constructor)]
public class SetsRequiredMembersAttribute : Attribute
{
}
#endif