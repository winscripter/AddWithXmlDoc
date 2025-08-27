using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AddWithXmlDoc.Core.CSharp;

internal static partial class RoslynSyntaxBuilders
{
    public static MethodDeclarationSyntax CreateObjectEquals(string typeName)
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
                                    SyntaxFactory.XmlExampleElement(
                                        SyntaxFactory.XmlText()
                                        .WithTextTokens(
                                            SyntaxFactory.TokenList(
                                                new []{
                                                    SyntaxFactory.XmlTextNewLine(
                                                        SyntaxFactory.TriviaList(),
                                                        "\n",
                                                        "\n",
                                                        SyntaxFactory.TriviaList()),
                                                    SyntaxFactory.XmlTextLiteral(
                                                        SyntaxFactory.TriviaList(
                                                            SyntaxFactory.DocumentationCommentExterior("///")),
                                                        " Determines if this instance is equal to the other instance of type ",
                                                        " Determines if this instance is equal to the other instance of type ",
                                                        SyntaxFactory.TriviaList())})),
                                        SyntaxFactory.XmlEmptyElement(
                                            SyntaxFactory.XmlName(
                                                SyntaxFactory.Identifier("see")))
                                        .WithAttributes(
                                            SyntaxFactory.SingletonList<XmlAttributeSyntax>(
                                                SyntaxFactory.XmlCrefAttribute(
                                                    SyntaxFactory.NameMemberCref(
                                                        SyntaxFactory.IdentifierName(typeName))))),
                                        SyntaxFactory.XmlText()
                                        .WithTextTokens(
                                            SyntaxFactory.TokenList(
                                                new []{
                                                    SyntaxFactory.XmlTextLiteral(
                                                        SyntaxFactory.TriviaList(),
                                                        ".",
                                                        ".",
                                                        SyntaxFactory.TriviaList()),
                                                    SyntaxFactory.XmlTextNewLine(
                                                        SyntaxFactory.TriviaList(),
                                                        "\n",
                                                        "\n",
                                                        SyntaxFactory.TriviaList()),
                                                    SyntaxFactory.XmlTextLiteral(
                                                        SyntaxFactory.TriviaList(
                                                            SyntaxFactory.DocumentationCommentExterior("///")),
                                                        " ",
                                                        " ",
                                                        SyntaxFactory.TriviaList())})))
                                    .WithStartTag(
                                        SyntaxFactory.XmlElementStartTag(
                                            SyntaxFactory.XmlName(
                                                SyntaxFactory.Identifier("summary"))))
                                    .WithEndTag(
                                        SyntaxFactory.XmlElementEndTag(
                                            SyntaxFactory.XmlName(
                                                SyntaxFactory.Identifier("summary")))),
                                    SyntaxFactory.XmlText()
                                    .WithTextTokens(
                                        SyntaxFactory.TokenList(
                                            new []{
                                                SyntaxFactory.XmlTextNewLine(
                                                    SyntaxFactory.TriviaList(),
                                                    "\n",
                                                    "\n",
                                                    SyntaxFactory.TriviaList()),
                                                SyntaxFactory.XmlTextLiteral(
                                                    SyntaxFactory.TriviaList(
                                                        SyntaxFactory.DocumentationCommentExterior("///")),
                                                    " ",
                                                    " ",
                                                    SyntaxFactory.TriviaList())})),
                                    SyntaxFactory.XmlExampleElement(
                                        SyntaxFactory.SingletonList<XmlNodeSyntax>(
                                            SyntaxFactory.XmlText()
                                            .WithTextTokens(
                                                SyntaxFactory.TokenList(
                                                    SyntaxFactory.XmlTextLiteral(
                                                        SyntaxFactory.TriviaList(),
                                                        "The other value to compare this instance with.",
                                                        "The other value to compare this instance with.",
                                                        SyntaxFactory.TriviaList())))))
                                    .WithStartTag(
                                        SyntaxFactory.XmlElementStartTag(
                                            SyntaxFactory.XmlName(
                                                SyntaxFactory.Identifier(
                                                    SyntaxFactory.TriviaList(),
                                                    SyntaxKind.ParamKeyword,
                                                    "param",
                                                    "param",
                                                    SyntaxFactory.TriviaList())))
                                        .WithAttributes(
                                            SyntaxFactory.SingletonList<XmlAttributeSyntax>(
                                                SyntaxFactory.XmlNameAttribute(
                                                    SyntaxFactory.XmlName(
                                                        SyntaxFactory.Identifier("name")),
                                                    SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken),
                                                    SyntaxFactory.IdentifierName("other"),
                                                    SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken)))))
                                    .WithEndTag(
                                        SyntaxFactory.XmlElementEndTag(
                                            SyntaxFactory.XmlName(
                                                SyntaxFactory.Identifier(
                                                    SyntaxFactory.TriviaList(),
                                                    SyntaxKind.ParamKeyword,
                                                    "param",
                                                    "param",
                                                    SyntaxFactory.TriviaList())))),
                                    SyntaxFactory.XmlText()
                                    .WithTextTokens(
                                        SyntaxFactory.TokenList(
                                            new []{
                                                SyntaxFactory.XmlTextNewLine(
                                                    SyntaxFactory.TriviaList(),
                                                    "\n",
                                                    "\n",
                                                    SyntaxFactory.TriviaList()),
                                                SyntaxFactory.XmlTextLiteral(
                                                    SyntaxFactory.TriviaList(
                                                        SyntaxFactory.DocumentationCommentExterior("///")),
                                                    " ",
                                                    " ",
                                                    SyntaxFactory.TriviaList())})),
                                    SyntaxFactory.XmlExampleElement(
                                        SyntaxFactory.XmlText()
                                        .WithTextTokens(
                                            SyntaxFactory.TokenList(
                                                SyntaxFactory.XmlTextLiteral(
                                                    SyntaxFactory.TriviaList(),
                                                    "A boolean that, if ",
                                                    "A boolean that, if ",
                                                    SyntaxFactory.TriviaList()))),
                                        SyntaxFactory.XmlEmptyElement(
                                            SyntaxFactory.XmlName(
                                                SyntaxFactory.Identifier("see")))
                                        .WithAttributes(
                                            SyntaxFactory.SingletonList<XmlAttributeSyntax>(
                                                SyntaxFactory.XmlTextAttribute(
                                                    SyntaxFactory.XmlName(
                                                        SyntaxFactory.Identifier("langword")),
                                                    SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken),
                                                    SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken))
                                                .WithTextTokens(
                                                    SyntaxFactory.TokenList(
                                                        SyntaxFactory.XmlTextLiteral(
                                                            SyntaxFactory.TriviaList(),
                                                            "true",
                                                            "true",
                                                            SyntaxFactory.TriviaList()))))),
                                        SyntaxFactory.XmlText()
                                        .WithTextTokens(
                                            SyntaxFactory.TokenList(
                                                SyntaxFactory.XmlTextLiteral(
                                                    SyntaxFactory.TriviaList(),
                                                    ", indicates that ",
                                                    ", indicates that ",
                                                    SyntaxFactory.TriviaList()))),
                                        SyntaxFactory.XmlEmptyElement(
                                            SyntaxFactory.XmlName(
                                                SyntaxFactory.Identifier("paramref")))
                                        .WithAttributes(
                                            SyntaxFactory.SingletonList<XmlAttributeSyntax>(
                                                SyntaxFactory.XmlNameAttribute(
                                                    SyntaxFactory.XmlName(
                                                        SyntaxFactory.Identifier("name")),
                                                    SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken),
                                                    SyntaxFactory.IdentifierName("other"),
                                                    SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken)))),
                                        SyntaxFactory.XmlText()
                                        .WithTextTokens(
                                            SyntaxFactory.TokenList(
                                                SyntaxFactory.XmlTextLiteral(
                                                    SyntaxFactory.TriviaList(),
                                                    " is equal to this instance, is of same type as this instance, and is not null.",
                                                    " is equal to this instance, is of same type as this instance, and is not null.",
                                                    SyntaxFactory.TriviaList()))))
                                    .WithStartTag(
                                        SyntaxFactory.XmlElementStartTag(
                                            SyntaxFactory.XmlName(
                                                SyntaxFactory.Identifier("returns"))))
                                    .WithEndTag(
                                        SyntaxFactory.XmlElementEndTag(
                                            SyntaxFactory.XmlName(
                                                SyntaxFactory.Identifier("returns")))),
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
