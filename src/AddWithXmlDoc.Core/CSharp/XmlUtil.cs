using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AddWithXmlDoc.Core.CSharp;

internal static class XmlUtil
{
    public static TypeDeclarationSyntax WithEqualsGetHashCodeOperatorsAndIEquatable(
        TypeDeclarationSyntax tds, IEnumerable<MemberDeclarationSyntax> members)
    {
        tds = AddIEquatableToBaseList(tds);

        string typeName = tds.Identifier.Text;
        List<string> memberNames = CollectMemberNames(members);

        tds = tds.AddMembers(
            RoslynSyntaxBuilders.CreateObjectEquals(typeName),
            RoslynSyntaxBuilders.CreateIEquatableEquals(memberNames, typeName),
            RoslynSyntaxBuilders.CreateGetHashCode(memberNames),
            RoslynSyntaxBuilders.CreateEqualsOperator(typeName),
            RoslynSyntaxBuilders.CreateNotEqualsOperator(typeName));

        tds = tds.NormalizeWhitespace();
        
        return tds;
    }

    private static List<string> CollectMemberNames(IEnumerable<MemberDeclarationSyntax> members)
    {
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
        return memberNames;
    }

    private static TypeDeclarationSyntax AddIEquatableToBaseList(TypeDeclarationSyntax input)
    {
        input = (TypeDeclarationSyntax)input.AddBaseListTypes(
            SyntaxFactory.SimpleBaseType(
                SyntaxFactory.GenericName(
                    SyntaxFactory.Identifier("IEquatable"))
                .WithTypeArgumentList(
                    SyntaxFactory.TypeArgumentList(
                        SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                            SyntaxFactory.NullableType(
                                SyntaxFactory.IdentifierName(input.Identifier.Text))))))
                .NormalizeWhitespace()
            );
        return input;
    }

    public static TypeDeclarationSyntax InheritdocWithEqualsGetHashCodeOperatorsAndIEquatable(
        TypeDeclarationSyntax tds, IEnumerable<MemberDeclarationSyntax> members)
    {
        tds = AddIEquatableToBaseList(tds);

        string typeName = tds.Identifier.Text;
        List<string> memberNames = CollectMemberNames(members);

        tds = tds.AddMembers(
            RoslynSyntaxBuilders.InheritDocObjectEquals(typeName),
            RoslynSyntaxBuilders.InheritDocIEquatableEquals(memberNames, typeName),
            RoslynSyntaxBuilders.InheritDocGetHashCode(memberNames),
            RoslynSyntaxBuilders.CreateEqualsOperator(typeName),
            RoslynSyntaxBuilders.CreateNotEqualsOperator(typeName));

        tds = tds.NormalizeWhitespace();

        return tds;
    }
}
