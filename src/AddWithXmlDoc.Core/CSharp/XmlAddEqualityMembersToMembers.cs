using AddWithXmlDoc.Core.Abstractions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;

namespace AddWithXmlDoc.Core.CSharp;

internal sealed class XmlAddEqualityMembersToMembers : IXmlAddEqualityMembersToMembers
{
    private SyntaxNode? _rootNode = null;

    public string Language => LanguageNames.CSharp;

    public bool UseInheritdocWherePossible { get; set; }

    public void Invoke(NewNodeDelegate del)
    {
        if (_rootNode == null)
            throw new InvalidOperationException("ProvideRootNode was not invoked");

        TypeDeclarationSyntax tds = (TypeDeclarationSyntax)_rootNode;

        del(
             UseInheritdocWherePossible
             ?
             XmlUtil.InheritdocWithEqualsGetHashCodeOperatorsAndIEquatable(
                 tds,
                 tds.Members.Where(m => m is FieldDeclarationSyntax or PropertyDeclarationSyntax))
             :
             XmlUtil.WithEqualsGetHashCodeOperatorsAndIEquatable(
                 tds,
                 tds.Members.Where(m => m is FieldDeclarationSyntax or PropertyDeclarationSyntax)));
    }

    public void ProvideRootNode(SyntaxNode syntaxNode)
    {
        _rootNode = syntaxNode;
    }
}
