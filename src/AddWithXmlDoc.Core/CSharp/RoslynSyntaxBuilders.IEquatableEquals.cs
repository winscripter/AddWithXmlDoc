using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace AddWithXmlDoc.Core.CSharp;

internal static partial class RoslynSyntaxBuilders
{
    public static BlockSyntax GenerateEqualityComparisonBody(IEnumerable<string> fieldNames)
    {
        ExpressionSyntax? combinedExpression = null;

        foreach (var field in fieldNames)
        {
            var thisField = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                SyntaxFactory.ThisExpression(),
                SyntaxFactory.IdentifierName(field));

            var otherField = SyntaxFactory.ConditionalAccessExpression(
                SyntaxFactory.IdentifierName("other"),
                SyntaxFactory.MemberBindingExpression(
                    SyntaxFactory.IdentifierName(field)))
            .NormalizeWhitespace();

            var equalsExpression = SyntaxFactory.BinaryExpression(
                SyntaxKind.EqualsExpression,
                thisField,
                otherField);

            combinedExpression = combinedExpression == null
                ? equalsExpression
                : SyntaxFactory.BinaryExpression(
                    SyntaxKind.LogicalAndExpression,
                    combinedExpression,
                    equalsExpression);
        }

        return SyntaxFactory.Block(
            SyntaxFactory.SingletonList<StatementSyntax>(
                SyntaxFactory.ReturnStatement(combinedExpression)));
    }

    public static MethodDeclarationSyntax CreateIEquatableEquals(IEnumerable<string> fieldNames, string typeName)
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
                                                    "The other instance to compare this instance with.",
                                                    "The other instance to compare this instance with.",
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
                                                " is equal to this instance.",
                                                " is equal to this instance.",
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
    GenerateEqualityComparisonBody(fieldNames))
.NormalizeWhitespace();
    }
}
