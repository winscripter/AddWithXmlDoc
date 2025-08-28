using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AddWithXmlDoc.Core.CSharp;

internal static partial class RoslynSyntaxBuilders
{
    public static MethodDeclarationSyntax InheritDocObjectEquals(string typeName)
    {
        return SyntaxFactory.MethodDeclaration(
    SyntaxFactory.PredefinedType(
        SyntaxFactory.Token(SyntaxKind.BoolKeyword)),
    SyntaxFactory.Identifier("Equals"))
.WithModifiers(
    SyntaxFactory.TokenList(
        new[]{
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
                                                    SyntaxFactory.IdentifierName("Object"),
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
                SyntaxFactory.TriviaList()),
            SyntaxFactory.Token(SyntaxKind.OverrideKeyword)}))
.WithParameterList(
    SyntaxFactory.ParameterList(
        SyntaxFactory.SingletonSeparatedList<ParameterSyntax>(
            SyntaxFactory.Parameter(
                SyntaxFactory.Identifier("other"))
            .WithType(
                SyntaxFactory.NullableType(
                    SyntaxFactory.PredefinedType(
                        SyntaxFactory.Token(SyntaxKind.ObjectKeyword)))))))
.WithBody(
    SyntaxFactory.Block(
        SyntaxFactory.SingletonList<StatementSyntax>(
            SyntaxFactory.ReturnStatement(
                SyntaxFactory.BinaryExpression(
                    SyntaxKind.LogicalAndExpression,
                    SyntaxFactory.IsPatternExpression(
                        SyntaxFactory.IdentifierName("other"),
                        SyntaxFactory.DeclarationPattern(
                            SyntaxFactory.IdentifierName(typeName),
                            SyntaxFactory.SingleVariableDesignation(
                                SyntaxFactory.Identifier("value")))),
                    SyntaxFactory.InvocationExpression(
                        SyntaxFactory.IdentifierName("Equals"))
                    .WithArgumentList(
                        SyntaxFactory.ArgumentList(
                            SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                SyntaxFactory.Argument(
                                    SyntaxFactory.IdentifierName("value"))))))))))
.NormalizeWhitespace();
    }
}
