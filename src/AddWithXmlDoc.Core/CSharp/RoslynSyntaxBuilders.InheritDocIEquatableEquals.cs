using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AddWithXmlDoc.Core.CSharp;

internal static partial class RoslynSyntaxBuilders
{
    public static MethodDeclarationSyntax InheritDocIEquatableEquals(IEnumerable<string> memberNames, string typeName)
    {
        return SyntaxFactory.MethodDeclaration(
    SyntaxFactory.PredefinedType(
        SyntaxFactory.Token(SyntaxKind.BoolKeyword)),
    SyntaxFactory.Identifier("Equals"))
.WithModifiers(
    SyntaxFactory.TokenList(
        SyntaxFactory.Token(
            SyntaxFactory.TriviaList(
                SyntaxFactory.Trivia(
                    SyntaxFactory.DocumentationCommentTrivia(
                        SyntaxKind.SingleLineDocumentationCommentTrivia,
                        SyntaxFactory.List<XmlNodeSyntax>(
                            new XmlNodeSyntax[]{
                                SyntaxFactory.XmlText()
                                .WithTextTokens(
                                    SyntaxFactory.TokenList(
                                        SyntaxFactory.XmlTextLiteral(
                                            SyntaxFactory.TriviaList(
                                                SyntaxFactory.DocumentationCommentExterior("///")),
                                            " ",
                                            " ",
                                            SyntaxFactory.TriviaList()))),
                                SyntaxFactory.XmlEmptyElement(
                                    SyntaxFactory.XmlName(
                                        SyntaxFactory.Identifier("inheritdoc")))
                                .WithAttributes(
                                    SyntaxFactory.SingletonList<XmlAttributeSyntax>(
                                        SyntaxFactory.XmlCrefAttribute(
                                            SyntaxFactory.QualifiedCref(
                                                SyntaxFactory.GenericName(
                                                    SyntaxFactory.Identifier("IEquatable"))
                                                .WithTypeArgumentList(
                                                    SyntaxFactory.TypeArgumentList(
                                                        SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                                            SyntaxFactory.IdentifierName("T")))),
                                                SyntaxFactory.NameMemberCref(
                                                    SyntaxFactory.IdentifierName("Equals")))))),
                                SyntaxFactory.XmlText()
                                .WithTextTokens(
                                    SyntaxFactory.TokenList(
                                        SyntaxFactory.XmlTextNewLine(
                                            SyntaxFactory.TriviaList(),
                                            "\n",
                                            "\n",
                                            SyntaxFactory.TriviaList())))})))),
            SyntaxKind.PublicKeyword,
            SyntaxFactory.TriviaList())))
.WithParameterList(
    SyntaxFactory.ParameterList(
        SyntaxFactory.SingletonSeparatedList<ParameterSyntax>(
            SyntaxFactory.Parameter(
                SyntaxFactory.Identifier("other"))
            .WithType(
                SyntaxFactory.NullableType(
                    SyntaxFactory.IdentifierName(typeName))))))
.WithBody(
        GenerateEqualityComparisonBody(memberNames))
.NormalizeWhitespace();
    }
}
