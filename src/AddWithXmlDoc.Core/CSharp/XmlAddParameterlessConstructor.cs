using AddWithXmlDoc.Core.Abstractions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace AddWithXmlDoc.Core.CSharp;

internal sealed class XmlAddParameterlessConstructor : IXmlAddParameterlessConstructor
{
    private SyntaxNode? _rootNode = null;

    public string Language => LanguageNames.CSharp;

    public void Invoke(NewNodeDelegate del)
    {
        if (_rootNode == null)
            throw new InvalidOperationException("ProvideRootNode was not invoked");

        // Do not add a parameterless constructor if it already exists.
        // We don't want to end up with two of them.

        if (AlreadyContainsParameterlessConstructor())
            return;

        TypeDeclarationSyntax tds = (TypeDeclarationSyntax)_rootNode;

        // Just add it!
        // Create the parameterless constructor first.

        ConstructorDeclarationSyntax cds = CreateParameterlessConstructorWithXmlDocumentation(tds.Identifier.Text);

        // Add it!
        tds = tds.AddMembers(cds);

        // Formatting
        tds = tds.NormalizeWhitespace();

        del(tds);
    }

    private static ConstructorDeclarationSyntax CreateParameterlessConstructorWithXmlDocumentation(string className)
    {
        return RoslynSyntaxBuilders.CreateParameterlessConstructor(className);
    }

    private bool AlreadyContainsParameterlessConstructor()
    {
        Debug.Assert(_rootNode != null, "Root Node is null");

        // Get TypeDeclarationSyntax
        TypeDeclarationSyntax tds = (TypeDeclarationSyntax)_rootNode;

        // Start by finding all of the constructor methods.
        ConstructorDeclarationSyntax[] constructors =
            [.. tds.DescendantNodes().OfType<ConstructorDeclarationSyntax>()];

        // Find the parameterless guys
        ConstructorDeclarationSyntax? parameterless =
            constructors.FirstOrDefault(x => x.ParameterList.Parameters.Count == 0);

        // If parameterless is null, return false.
        return parameterless is not null;
    }

    public void ProvideRootNode(SyntaxNode syntaxNode)
    {
        _rootNode = syntaxNode;
    }
}
