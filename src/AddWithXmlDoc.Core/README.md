# AddWithXmlDoc.Core
This is the core library for AddWithXmlDoc, a Visual Studio extension to add XML-documented members to classes.

It currently supports C#.

### Usage
Start by parsing an input class.

Source (as a string variable named `inputCode`):
```cs
public class MyClass
{
    public string MyString { get; set; } = "Hello, World!";
    public int MyNumber { get; set; } = 42;
    public bool MyBoolean { get; set; } = true;
    public double MyDouble { get; set; } = 3.14;
    public DateTime MyDateTime { get; set; } = DateTime.Now;
}
```

Parse it and get the `TypeDeclarationSyntax`:
```cs
using Microsoft.CodeAnalysis.CSharp;

var declaration = CSharpSyntaxTree.ParseText(inputCode)
    .GetRoot()
    .DescendantNodes()
    .OfType<TypeDeclarationSyntax>()
    .First();
```

Create a `LanguageServicesContainer` instance for C#.

```
var container = LanguageServicesContainer.CreateCSharp();
```

Use the `AddEqualityMembersToMembers` method to add equality members to fields and properties.

```cs
container.AddEqualityMembersToMembers.ProvideRootNode(declaration);
container.AddEqualityMembersToMembers.Invoke(
    (result) =>
    {
        Console.WriteLine(result.ToString());
    });
```

Result:
```cs
public class MyClass : IEquatable<MyClass>
{
    public string MyString { get; set; } = "Hello, World!";
    public int MyNumber { get; set; } = 42;
    public bool MyBoolean { get; set; } = true;
    public double MyDouble { get; set; } = 3.14;
    public DateTime MyDateTime { get; set; } = DateTime.Now;

    /// <summary>
    /// Determines if this instance is equal to the other instance of type <see cref = "MyClass"/>.
    /// </summary>
    /// <param name = "other">The other value to compare this instance with.</param>
    /// <returns>A boolean that, if <see langword="true"/>, indicates that <paramref name = "other"/> is equal to this instance, is of same type as this instance, and is not null.</returns>
    public override bool Equals(object? other)
    {
        return other is MyClass value && Equals(value);
    }

    /// <summary>
    /// Determines if this instance is equal to the other instance of type <see cref = "MyClass"/>.
    /// </summary>
    /// <param name = "other">The other instance to compare this instance with.</param>
    /// <returns>A boolean that, if <see langword="true"/>, indicates that <paramref name = "other"/> is equal to this instance.</returns>
    public bool Equals(MyClass? other)
    {
        return this.MyString == other?.MyString && this.MyNumber == other?.MyNumber && this.MyBoolean == other?.MyBoolean && this.MyDouble == other?.MyDouble && this.MyDateTime == other?.MyDateTime;
    }

    /// <summary>
    /// Computes the hash code for this object.
    /// </summary>
    /// <returns>This object's hash code.</returns>
    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(this.MyString);
        hashCode.Add(this.MyNumber);
        hashCode.Add(this.MyBoolean);
        hashCode.Add(this.MyDouble);
        hashCode.Add(this.MyDateTime);
        return hashCode.ToHashCode();
    }

    /// <summary>
    /// Determines if <paramref name = "left"/> is equal to <paramref name = "right"/>.
    /// </summary>
    /// <param name = "left">The value to compare from.</param>
    /// <param name = "right">The value to compare with.</param>
    /// <returns><see langword="true"/> if the left parameter is same as the right parameter, otherwise <see langword="false"/>.</returns>
    public static bool operator ==(MyClass left, MyClass right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Determines if <paramref name = "left"/> is not equal to <paramref name = "right"/>.
    /// </summary>
    /// <param name = "left">The value to compare from.</param>
    /// <param name = "right">The value to compare with.</param>
    /// <returns><see langword="true"/> if the left parameter is different compared to the right parameter, otherwise <see langword="false"/> if both are same.</returns>
    public static bool operator !=(MyClass left, MyClass right)
    {
        return !(left == right);
    }
}
```

Use `AddEqualityMembersToFields` to only target fields, and `AddEqualityMembersToProperties` to only target properties.

Use `AddParameterlessConstructor` to add a parameterless constructor. Usage is the same as for `AddEqualityMembersToMembers`. Result:

```cs
public class MyClass
{
    public string MyString { get; set; } = "Hello, World!";
    public int MyNumber { get; set; } = 42;
    public bool MyBoolean { get; set; } = true;
    public double MyDouble { get; set; } = 3.14;
    public DateTime MyDateTime { get; set; } = DateTime.Now;

    /// <summary>
    /// Initializes a new instance of the <see cref="MyClass" /> class.
    /// </summary>
    public MyClass()
    {
    }
}
```
