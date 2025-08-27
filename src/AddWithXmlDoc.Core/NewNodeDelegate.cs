using AddWithXmlDoc.Core.Abstractions;
using Microsoft.CodeAnalysis;

namespace AddWithXmlDoc.Core;

/// <summary>
///   Invoked as soon as the <see cref="IXmlAdd.Invoke"/> method requests
///   the modified node.
/// </summary>
/// <param name="receivedNode">The new node.</param>
public delegate void NewNodeDelegate(SyntaxNode receivedNode);
