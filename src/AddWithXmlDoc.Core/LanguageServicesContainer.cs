using AddWithXmlDoc.Core.Abstractions;
using AddWithXmlDoc.Core.CSharp;
using Microsoft.CodeAnalysis;

namespace AddWithXmlDoc.Core;

/// <summary>
///   A language services container.
/// </summary>
public abstract class LanguageServicesContainer
{
    /// <summary>
    ///   Creates a C# Language Services Container.
    /// </summary>
    /// <returns><see cref="LanguageServicesContainer"/> for C#</returns>
    public static LanguageServicesContainer CreateCSharp() => new CSharpLanguageServicesContainer();

    /// <summary>
    ///   Language for all of the services in this service container, provided by the <see cref="LanguageNames"/> class.
    /// </summary>
    public abstract string Language { get; }

    /// <summary>
    ///   Add Equality Members To Fields language service.
    /// </summary>
    public abstract IXmlAddEqualityMembersToFields AddEqualityMembersToFields { get; }

    /// <summary>
    ///   Add Equality Members To Properties language service.
    /// </summary>
    public abstract IXmlAddEqualityMembersToProperties AddEqualityMembersToProperties { get; }

    /// <summary>
    ///   Add Equality Members To Members language service.
    /// </summary>
    public abstract IXmlAddEqualityMembersToMembers AddEqualityMembersToMembers { get; }

    /// <summary>
    ///   Add Parameterless Constructor language service.
    /// </summary>
    public abstract IXmlAddParameterlessConstructor AddParameterlessConstructor { get; }
}
