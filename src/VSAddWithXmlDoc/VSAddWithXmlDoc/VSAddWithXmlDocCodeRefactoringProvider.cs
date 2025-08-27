using AddWithXmlDoc.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeRefactorings;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Composition;
using System.Threading;
using System.Threading.Tasks;

namespace AddWithXmlDoc.VS
{
    [ExportCodeRefactoringProvider(LanguageNames.CSharp, Name = nameof(AddWithXmlDocVSCodeRefactoringProvider)), Shared]
    public class AddWithXmlDocVSCodeRefactoringProvider : CodeRefactoringProvider
    {
        private static readonly LanguageServicesContainer languageServicesContainer =
            LanguageServicesContainer.CreateCSharp();

        public sealed override async Task ComputeRefactoringsAsync(CodeRefactoringContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
            var node = root.FindNode(context.Span);

            TypeDeclarationSyntax typeDecl = null;
            if (node is ClassDeclarationSyntax cl)
                typeDecl = cl;
            else if (node is StructDeclarationSyntax st)
                typeDecl = st;
            else
                return;

            var eqFields = CodeAction.Create("XML: Add Equality Methods to Fields", c => XAddEqualityToFields(context.Document, typeDecl, c));
            context.RegisterRefactoring(eqFields);

            var eqProps = CodeAction.Create("XML: Add Equality Methods to Properties", c => XAddEqualityToProperties(context.Document, typeDecl, c));
            context.RegisterRefactoring(eqProps);

            var eqMembers = CodeAction.Create("XML: Add Equality Methods to Members", c => XAddEqualityToMembers(context.Document, typeDecl, c));
            context.RegisterRefactoring(eqMembers);

            var pc = CodeAction.Create("XML: Add Parameterless Constructor", c => AddParameterlessConstructor(context.Document, typeDecl, c));
            context.RegisterRefactoring(pc);
        }

        private async Task<Solution> XAddEqualityToFields(Document document, TypeDeclarationSyntax typeDecl, CancellationToken cancellationToken)
        {
            var synRoot = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            SyntaxNode newRoot = synRoot;

            languageServicesContainer.AddEqualityMembersToFields.ProvideRootNode(typeDecl);
            languageServicesContainer.AddEqualityMembersToFields.Invoke(
                (updatedNode) =>
                {
                    newRoot = synRoot.ReplaceNode(typeDecl, updatedNode);
                });

            var newDocument = document.WithSyntaxRoot(newRoot);
            return newDocument.Project.Solution;
        }

        private async Task<Solution> XAddEqualityToProperties(Document document, TypeDeclarationSyntax typeDecl, CancellationToken cancellationToken)
        {
            var synRoot = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            SyntaxNode newRoot = synRoot;

            languageServicesContainer.AddEqualityMembersToProperties.ProvideRootNode(typeDecl);
            languageServicesContainer.AddEqualityMembersToProperties.Invoke(
                (updatedNode) =>
                {
                    newRoot = synRoot.ReplaceNode(typeDecl, updatedNode);
                });

            var newDocument = document.WithSyntaxRoot(newRoot);
            return newDocument.Project.Solution;
        }

        private async Task<Solution> XAddEqualityToMembers(Document document, TypeDeclarationSyntax typeDecl, CancellationToken cancellationToken)
        {
            var synRoot = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            SyntaxNode newRoot = synRoot;

            languageServicesContainer.AddEqualityMembersToMembers.ProvideRootNode(typeDecl);
            languageServicesContainer.AddEqualityMembersToMembers.Invoke(
                (updatedNode) =>
                {
                    newRoot = synRoot.ReplaceNode(typeDecl, updatedNode);
                });

            var newDocument = document.WithSyntaxRoot(newRoot);
            return newDocument.Project.Solution;
        }

        private async Task<Solution> AddParameterlessConstructor(Document document, TypeDeclarationSyntax typeDecl, CancellationToken cancellationToken)
        {
            var synRoot = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            SyntaxNode newRoot = synRoot;

            languageServicesContainer.AddParameterlessConstructor.ProvideRootNode(typeDecl);
            languageServicesContainer.AddParameterlessConstructor.Invoke(
                (updatedNode) =>
                {
                    newRoot = synRoot.ReplaceNode(typeDecl, updatedNode);
                });

            var newDocument = document.WithSyntaxRoot(newRoot);
            return newDocument.Project.Solution;
        }
    }
}
