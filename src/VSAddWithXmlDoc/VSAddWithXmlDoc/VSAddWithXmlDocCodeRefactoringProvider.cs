using AddWithXmlDoc.Core;
using AddWithXmlDoc.Core.Abstractions;
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

            context.RegisterRefactoring(
                CodeAction.Create("XML: Add Equality Methods to Fields", c => XAddEqualityToFields(context.Document, typeDecl, c)));
            context.RegisterRefactoring(
                CodeAction.Create("XML: Add Equality Methods to Properties", c => XAddEqualityToProperties(context.Document, typeDecl, c)));
            context.RegisterRefactoring(
                CodeAction.Create("XML: Add Equality Methods to Members", c => XAddEqualityToMembers(context.Document, typeDecl, c)));
            context.RegisterRefactoring(
                CodeAction.Create("XML: Add Parameterless Constructor", c => AddParameterlessConstructor(context.Document, typeDecl, c)));
            context.RegisterRefactoring(
                CodeAction.Create("XML: Add Equality Methods to Fields (Use inheritdoc)", c => IXAddEqualityToFields(context.Document, typeDecl, c)));
            context.RegisterRefactoring(
                CodeAction.Create("XML: Add Equality Methods to Properties (Use inheritdoc)", c => IXAddEqualityToProperties(context.Document, typeDecl, c)));
            context.RegisterRefactoring(
                CodeAction.Create("XML: Add Equality Methods to Members (Use inheritdoc)", c => IXAddEqualityToMembers(context.Document, typeDecl, c)));
        }

        private Solution ApplyChangesWithInheritDoc(Document document, TypeDeclarationSyntax typeDecl, IXmlAdd xmlAdd, SyntaxNode root)
        {
            xmlAdd.UseInheritdocWherePossible = true;
            return ApplyChanges(document, typeDecl, xmlAdd, root);
        }

        private Solution ApplyChanges(Document document, TypeDeclarationSyntax typeDecl, IXmlAdd xmlAdd, SyntaxNode root)
        {
            SyntaxNode newRoot = root;

            xmlAdd.ProvideRootNode(typeDecl);
            xmlAdd.Invoke(
                (updatedNode) =>
                {
                    newRoot = root.ReplaceNode(typeDecl, updatedNode);
                });

            var newDocument = document.WithSyntaxRoot(newRoot);
            return newDocument.Project.Solution;
        }

        private async Task<Solution> XAddEqualityToFields(Document document, TypeDeclarationSyntax typeDecl, CancellationToken cancellationToken)
        {
            var synRoot = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            return ApplyChanges(document, typeDecl, languageServicesContainer.AddEqualityMembersToFields, synRoot);
        }

        private async Task<Solution> XAddEqualityToProperties(Document document, TypeDeclarationSyntax typeDecl, CancellationToken cancellationToken)
        {
            var synRoot = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            return ApplyChanges(document, typeDecl, languageServicesContainer.AddEqualityMembersToProperties, synRoot);
        }

        private async Task<Solution> XAddEqualityToMembers(Document document, TypeDeclarationSyntax typeDecl, CancellationToken cancellationToken)
        {
            var synRoot = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            return ApplyChanges(document, typeDecl, languageServicesContainer.AddEqualityMembersToMembers, synRoot);
        }

        private async Task<Solution> AddParameterlessConstructor(Document document, TypeDeclarationSyntax typeDecl, CancellationToken cancellationToken)
        {
            var synRoot = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            return ApplyChanges(document, typeDecl, languageServicesContainer.AddParameterlessConstructor, synRoot);
        }

        private async Task<Solution> IXAddEqualityToFields(Document document, TypeDeclarationSyntax typeDecl, CancellationToken cancellationToken)
        {
            var synRoot = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            return ApplyChangesWithInheritDoc(document, typeDecl, languageServicesContainer.AddEqualityMembersToFields, synRoot);
        }

        private async Task<Solution> IXAddEqualityToProperties(Document document, TypeDeclarationSyntax typeDecl, CancellationToken cancellationToken)
        {
            var synRoot = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            return ApplyChangesWithInheritDoc(document, typeDecl, languageServicesContainer.AddEqualityMembersToProperties, synRoot);
        }

        private async Task<Solution> IXAddEqualityToMembers(Document document, TypeDeclarationSyntax typeDecl, CancellationToken cancellationToken)
        {
            var synRoot = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            return ApplyChangesWithInheritDoc(document, typeDecl, languageServicesContainer.AddEqualityMembersToMembers, synRoot);
        }
    }
}
