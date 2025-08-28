using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AddWithXmlDoc.Core.CSharp;

internal static class XmlUtil
{
    public static TypeDeclarationSyntax WithEqualsGetHashCodeOperatorsAndIEquatable(
        TypeDeclarationSyntax tds, IEnumerable<MemberDeclarationSyntax> members)
    {
        // Add IEquatable`1 to the base list
        tds = (TypeDeclarationSyntax)tds.AddBaseListTypes(
            SyntaxFactory.SimpleBaseType(
                SyntaxFactory.GenericName(
                    SyntaxFactory.Identifier("IEquatable"))
            .WithTypeArgumentList(
                SyntaxFactory.TypeArgumentList(
                    SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                        SyntaxFactory.IdentifierName(tds.Identifier.Text))))
            .NormalizeWhitespace()
            ));

        string typeName = tds.Identifier.Text;

        List<string> memberNames = [];
        foreach (var member in members)
        {
            if (member is FieldDeclarationSyntax fds)
            {
                foreach (var variable in fds.Declaration.Variables)
                {
                    memberNames.Add(variable.Identifier.Text);
                }
            }
            else if (member is PropertyDeclarationSyntax pds)
            {
                memberNames.Add(pds.Identifier.Text);
            }
        }

        tds = tds.AddMembers(
            RoslynSyntaxBuilders.CreateObjectEquals(typeName),
            RoslynSyntaxBuilders.CreateIEquatableEquals(memberNames, typeName),
            RoslynSyntaxBuilders.CreateGetHashCode(memberNames),
            RoslynSyntaxBuilders.CreateEqualsOperator(typeName),
            RoslynSyntaxBuilders.CreateNotEqualsOperator(typeName));

        tds = tds.NormalizeWhitespace();
        
        return tds;
    }
}
