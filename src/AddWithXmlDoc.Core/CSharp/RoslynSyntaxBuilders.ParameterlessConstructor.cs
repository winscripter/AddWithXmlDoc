using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AddWithXmlDoc.Core.CSharp;

internal static partial class RoslynSyntaxBuilders
{
    public static ConstructorDeclarationSyntax CreateParameterlessConstructor(string typeName)
    {
        return SyntaxFactory.ConstructorDeclaration(
    SyntaxFactory.Identifier(typeName))
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
                                                    " Initializes a new instance of the ",
                                                    " Initializes a new instance of the ",
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
                                                    " class.",
                                                    " class.",
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
                                        SyntaxFactory.XmlTextNewLine(
                                            SyntaxFactory.TriviaList(),
                                            "\n",
                                            "\n",
                                            SyntaxFactory.TriviaList())))})))),
            SyntaxKind.PublicKeyword,
            SyntaxFactory.TriviaList())))
.WithBody(
    SyntaxFactory.Block())
.NormalizeWhitespace();
    }
}
