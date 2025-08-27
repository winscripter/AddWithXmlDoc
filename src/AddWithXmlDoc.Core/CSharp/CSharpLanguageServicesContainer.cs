using AddWithXmlDoc.Core.Abstractions;
using Microsoft.CodeAnalysis;

namespace AddWithXmlDoc.Core.CSharp;

internal sealed class CSharpLanguageServicesContainer : LanguageServicesContainer
{
    private readonly Lazy<IXmlAddEqualityMembersToFields> _addEqualityMembersToFields =
        new(() => new XmlAddEqualityMembersToFields());
    private readonly Lazy<IXmlAddEqualityMembersToProperties> _addEqualityMembersToProperties =
        new(() => new XmlAddEqualityMembersToProperties());
    private readonly Lazy<IXmlAddEqualityMembersToMembers> _addEqualityMembersToMembers =
        new(() => new XmlAddEqualityMembersToMembers());
    private readonly Lazy<IXmlAddParameterlessConstructor> _addParameterlessConstructor =
        new(() => new XmlAddParameterlessConstructor());

    public override string Language => LanguageNames.CSharp;

    public override IXmlAddEqualityMembersToFields AddEqualityMembersToFields => _addEqualityMembersToFields.Value;

    public override IXmlAddEqualityMembersToProperties AddEqualityMembersToProperties => _addEqualityMembersToProperties.Value;

    public override IXmlAddEqualityMembersToMembers AddEqualityMembersToMembers => _addEqualityMembersToMembers.Value;

    public override IXmlAddParameterlessConstructor AddParameterlessConstructor => _addParameterlessConstructor.Value;
}
