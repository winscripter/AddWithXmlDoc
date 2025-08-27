using AddWithXmlDoc.Core.Abstractions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AddWithXmlDoc.Core.CSharp;

internal sealed class XmlAddEqualityMembersToFields : IXmlAddEqualityMembersToFields
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
            tds.Members.Where(m => m is FieldDeclarationSyntax)));
    }

    public void ProvideRootNode(SyntaxNode syntaxNode)
    {
        _rootNode = syntaxNode;
    }
}
