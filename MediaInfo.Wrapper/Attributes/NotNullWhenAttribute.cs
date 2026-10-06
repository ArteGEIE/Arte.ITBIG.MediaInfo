#if NETFRAMEWORK

namespace System.Diagnostics.CodeAnalysis;

/// <summary>
/// Indicates that a parameter is not null when the method returns a specified Boolean value.
/// </summary>
/// <remarks>Apply this attribute to a method parameter to inform static analysis tools that the parameter will be
/// non-null when the method returns the specified Boolean value. This is commonly used to improve null-state flow
/// analysis and to document conditional nullability contracts.</remarks>
/// <param name="returnValue">The return value condition. If the method returns this value, the associated parameter will not be null.</param>
[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
public sealed class NotNullWhenAttribute(bool returnValue) : Attribute
{
    /// <summary>
    /// Gets a value indicating whether the operation was successful.
    /// </summary>
    public bool ReturnValue { get; } = returnValue;
}

#endif