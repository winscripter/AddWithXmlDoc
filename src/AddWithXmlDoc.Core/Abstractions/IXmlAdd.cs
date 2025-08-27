using Microsoft.CodeAnalysis;

namespace AddWithXmlDoc.Core.Abstractions;

/// <summary>
///   Base service to add values to types with XML documentation.
/// </summary>
public interface IXmlAdd
{
    /// <summary>
    ///   Provides the root node to use.
    ///   <example>
    ///     <para><em>Example</em></para>
    ///     
    ///     If <paramref name="syntaxNode"/> depicts a class or struct,
    ///     things will be added into it with XML documentation.
    ///   </example>
    /// </summary>
    /// <param name="syntaxNode">The root node.</param>
    /// <remarks>
    ///   The provided node must be language-specific. If this
    ///   <see cref="IXmlAdd"/> implementation receives C#-only syntax
    ///   nodes, a Visual Basic syntax node cannot be provided.
    /// </remarks>
    void ProvideRootNode(SyntaxNode syntaxNode);

    /// <summary>
    ///   The language that this <see cref="IXmlAdd"/> implementation supports.
    ///   The language name is provided by the <see cref="LanguageNames"/> class.
    /// </summary>
    /// <remarks>
    ///   The language influences what nodes can be passed to the
    ///   <see cref="ProvideRootNode(SyntaxNode)"/> method.
    /// </remarks>
    string Language { get; }

    /// <summary>
    ///   Begins the operation.
    /// </summary>
    /// <param name="del">Once the operation is complete, the new node is sent here.</param>
    void Invoke(NewNodeDelegate del);
}
