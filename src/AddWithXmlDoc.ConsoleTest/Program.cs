using AddWithXmlDoc.ConsoleTest;
using AddWithXmlDoc.Core;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

Console.WriteLine("Default snippet:");
Console.WriteLine(Snippets.Snippet);

var parsed = CSharpSyntaxTree.ParseText(Snippets.Snippet);

var csharpLSC = LanguageServicesContainer.CreateCSharp();

var type = parsed.GetRoot().DescendantNodes().OfType<TypeDeclarationSyntax>().First();

csharpLSC.AddEqualityMembersToFields.ProvideRootNode(type);
csharpLSC.AddEqualityMembersToFields.Invoke((newNode) =>
{
    Console.WriteLine("Equality to Fields:");
    Console.WriteLine(newNode.ToString());
});

csharpLSC.AddEqualityMembersToProperties.ProvideRootNode(type);
csharpLSC.AddEqualityMembersToProperties.Invoke((newNode) =>
{
    Console.WriteLine("Equality to Properties:");
    Console.WriteLine(newNode.ToString());
});

csharpLSC.AddEqualityMembersToMembers.ProvideRootNode(type);
csharpLSC.AddEqualityMembersToMembers.Invoke((newNode) =>
{
    Console.WriteLine("Equality to Members:");
    Console.WriteLine(newNode.ToString());
});

csharpLSC.AddParameterlessConstructor.ProvideRootNode(type);
csharpLSC.AddParameterlessConstructor.Invoke((newNode) =>
{
    Console.WriteLine("Parameterless Constructor:");
    Console.WriteLine(newNode.ToString());
});
