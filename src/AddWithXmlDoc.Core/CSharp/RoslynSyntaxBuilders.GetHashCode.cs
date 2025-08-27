using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AddWithXmlDoc.Core.CSharp;

internal static partial class RoslynSyntaxBuilders
{
    public static MethodDeclarationSyntax CreateGetHashCode(IEnumerable<string> members)
    {
        var expressions = new List<ExpressionStatementSyntax>();
        foreach (string member in members)
        {
            expressions.Add(
                SyntaxFactory.ExpressionStatement(
            SyntaxFactory.InvocationExpression(
                SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    SyntaxFactory.IdentifierName("hashCode"),
                    SyntaxFactory.IdentifierName("Add")))
            .WithArgumentList(
                SyntaxFactory.ArgumentList(
                    SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                        SyntaxFactory.Argument(
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.ThisExpression(),
                                SyntaxFactory.IdentifierName(member))))))));
        }

        return SyntaxFactory.MethodDeclaration(
    SyntaxFactory.PredefinedType(
        SyntaxFactory.Token(SyntaxKind.IntKeyword)),
    SyntaxFactory.Identifier("GetHashCode"))
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
                                        SyntaxFactory.SingletonList<XmlNodeSyntax>(
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
                                                            " Computes the hash code for this object.",
                                                            " Computes the hash code for this object.",
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
                                                            SyntaxFactory.TriviaList())}))))
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
                                                        "This object's hash code.",
                                                        "This object's hash code.",
                                                        SyntaxFactory.TriviaList())))))
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
.WithBody(
    SyntaxFactory.Block(
        new SyntaxList<StatementSyntax>([
            SyntaxFactory.LocalDeclarationStatement(
                SyntaxFactory.VariableDeclaration(
                    SyntaxFactory.IdentifierName(
                        SyntaxFactory.Identifier(
                            SyntaxFactory.TriviaList(),
                            SyntaxKind.VarKeyword,
                            "var",
                            "var",
                            SyntaxFactory.TriviaList())))
                .WithVariables(
                    SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                        SyntaxFactory.VariableDeclarator(
                            SyntaxFactory.Identifier("hashCode"))
                        .WithInitializer(
                            SyntaxFactory.EqualsValueClause(
                                SyntaxFactory.ObjectCreationExpression(
                                    SyntaxFactory.IdentifierName("HashCode"))
                                .WithArgumentList(
                                    SyntaxFactory.ArgumentList())))))),
            .. expressions,
            SyntaxFactory.ReturnStatement(
                SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName("hashCode"),
                        SyntaxFactory.IdentifierName("ToHashCode"))))
        ])))
.NormalizeWhitespace();
    }
}
