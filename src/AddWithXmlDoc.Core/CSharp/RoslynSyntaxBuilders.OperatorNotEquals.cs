using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AddWithXmlDoc.Core.CSharp;

internal static partial class RoslynSyntaxBuilders
{
    public static OperatorDeclarationSyntax CreateNotEqualsOperator(string typeName)
    {
        return SyntaxFactory.OperatorDeclaration(
    SyntaxFactory.PredefinedType(
        SyntaxFactory.Token(SyntaxKind.BoolKeyword)),
    SyntaxFactory.Token(SyntaxKind.ExclamationEqualsToken))
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
                                                        " Determines if ",
                                                        " Determines if ",
                                                        SyntaxFactory.TriviaList())})),
                                        SyntaxFactory.XmlEmptyElement(
                                            SyntaxFactory.XmlName(
                                                SyntaxFactory.Identifier("paramref")))
                                        .WithAttributes(
                                            SyntaxFactory.SingletonList<XmlAttributeSyntax>(
                                                SyntaxFactory.XmlNameAttribute(
                                                    SyntaxFactory.XmlName(
                                                        SyntaxFactory.Identifier("name")),
                                                    SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken),
                                                    SyntaxFactory.IdentifierName("left"),
                                                    SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken)))),
                                        SyntaxFactory.XmlText()
                                        .WithTextTokens(
                                            SyntaxFactory.TokenList(
                                                SyntaxFactory.XmlTextLiteral(
                                                    SyntaxFactory.TriviaList(),
                                                    " is not equal to ",
                                                    " is not equal to ",
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
                                                    SyntaxFactory.IdentifierName("right"),
                                                    SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken)))),
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
                                                        "The value to compare from.",
                                                        "The value to compare from.",
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
                                                    SyntaxFactory.IdentifierName("left"),
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
                                        SyntaxFactory.SingletonList<XmlNodeSyntax>(
                                            SyntaxFactory.XmlText()
                                            .WithTextTokens(
                                                SyntaxFactory.TokenList(
                                                    SyntaxFactory.XmlTextLiteral(
                                                        SyntaxFactory.TriviaList(),
                                                        "The value to compare with.",
                                                        "The value to compare with.",
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
                                                    SyntaxFactory.IdentifierName("right"),
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
                                                    " if the left parameter is different compared to the right parameter, otherwise ",
                                                    " if the left parameter is different compared to the right parameter, otherwise ",
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
                                                            "false",
                                                            "false",
                                                            SyntaxFactory.TriviaList()))))),
                                        SyntaxFactory.XmlText()
                                        .WithTextTokens(
                                            SyntaxFactory.TokenList(
                                                SyntaxFactory.XmlTextLiteral(
                                                    SyntaxFactory.TriviaList(),
                                                    " if both are same.",
                                                    " if both are same.",
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
            SyntaxFactory.Token(SyntaxKind.StaticKeyword)}))
.WithParameterList(
    SyntaxFactory.ParameterList(
        SyntaxFactory.SeparatedList<ParameterSyntax>(
            new SyntaxNodeOrToken[]{
                SyntaxFactory.Parameter(
                    SyntaxFactory.Identifier("left"))
                .WithType(
                    SyntaxFactory.IdentifierName(typeName)),
                SyntaxFactory.Token(SyntaxKind.CommaToken),
                SyntaxFactory.Parameter(
                    SyntaxFactory.Identifier("right"))
                .WithType(
                    SyntaxFactory.IdentifierName(typeName))})))
.WithBody(
    SyntaxFactory.Block(
        SyntaxFactory.SingletonList<StatementSyntax>(
            SyntaxFactory.ReturnStatement(
                SyntaxFactory.PrefixUnaryExpression(
                    SyntaxKind.LogicalNotExpression,
                    SyntaxFactory.ParenthesizedExpression(
                        SyntaxFactory.BinaryExpression(
                            SyntaxKind.EqualsExpression,
                            SyntaxFactory.IdentifierName("left"),
                            SyntaxFactory.IdentifierName("right"))))))))
.NormalizeWhitespace();
    }
}
