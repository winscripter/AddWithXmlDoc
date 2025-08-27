using AddWithXmlDoc.Core.Abstractions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;

namespace AddWithXmlDoc.Core.CSharp;

internal sealed class XmlAddEqualityMembersToProperties : IXmlAddEqualityMembersToProperties
{
    private SyntaxNode? _rootNode = null;

    public string Language => LanguageNames.CSharp;

    public void Invoke(NewNodeDelegate del)
    {
        if (_rootNode == null)
            throw new InvalidOperationException("ProvideRootNode was not invoked");

        TypeDeclarationSyntax tds = (TypeDeclarationSyntax)_rootNode;

        del(XmlUtil.WithEqualsGetHashCodeOperatorsAndIEquatable(
            tds,
            tds.Members.Where(m => m is PropertyDeclarationSyntax)));
    }

    public void ProvideRootNode(SyntaxNode syntaxNode)
    {
        _rootNode = syntaxNode;
    }
}
