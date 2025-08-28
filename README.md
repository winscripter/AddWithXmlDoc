# 📃 AddWithXmlDoc
A Visual Studio extension that lets you generate common methods in C# - parameterless constructors, `GetHashCode`, `Equals`, and equality operators - with XML documentation automatically inserted for you.

# ❓ How does it work?
When you install the extension, you get four new code actions for classes and structs!

- `XML: Add Equality Methods to Fields`: When you click this, it generates `GetHashCode`, `Equals`, `IEquatable`, and equality operators for all fields, + XML documentation.
- `XML: Add Equality Methods to Properties`: Same as the one above, but for properties.
- `XML: Add Equality Methods to Members`: Same as the one above, but for both Fields and Properties.
- `XML: Add Parameterless Constructor`: Adds an empty constructor without any parameters, with XML documentation

You no longer have to manually write XML documentation for methods like `GetHashCode` or `Equals` - even an `<inheritdoc ... />` can take some time to write! AddWithXmlDoc does that for you.

# ✨ Example
Imagine we have a class:
```cs
public class Class1
{
    public string Greeting { get; set; }
        = "Welcome to AddWithXmlDoc!"
}
```

Right click on `Class1`. Click `XML: Add Equality Methods to Members`.
Our class now looks like this. With just one click.

```cs
public class Class1 : IEquatable<Class1>
{
    public string Greeting { get; set; }
        = "Welcome to AddWithXmlDoc!"

    /// <summary>
    /// Determines if this instance is equal to the other instance of type <see cref = "Class1"/>.
    /// </summary>
    /// <param name = "other">The other value to compare this instance with.</param>
    /// <returns>A boolean that, if <see langword="true"/>, indicates that <paramref name = "other"/> is equal to this instance, is of same type as this instance, and is not null.</returns>
    public override bool Equals(object? other)
    {
        return other is Class1 value && Equals(value);
    }

    /// <summary>
    /// Determines if this instance is equal to the other instance of type <see cref = "Class1"/>.
    /// </summary>
    /// <param name = "other">The other instance to compare this instance with.</param>
    /// <returns>A boolean that, if <see langword="true"/>, indicates that <paramref name = "other"/> is equal to this instance.</returns>
    public bool Equals(Class1? other)
    {
        return this.Greeting == other?.Greeting;
    }

    /// <summary>
    /// Computes the hash code for this object.
    /// </summary>
    /// <returns>This object's hash code.</returns>
    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(this.Greeting);
        return hashCode.ToHashCode();
    }

    /// <summary>
    /// Determines if <paramref name = "left"/> is equal to <paramref name = "right"/>.
    /// </summary>
    /// <param name = "left">The value to compare from.</param>
    /// <param name = "right">The value to compare with.</param>
    /// <returns><see langword="true"/> if the left parameter is same as the right parameter, otherwise <see langword="false"/>.</returns>
    public static bool operator ==(Class1 left, Class1 right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Determines if <paramref name = "left"/> is not equal to <paramref name = "right"/>.
    /// </summary>
    /// <param name = "left">The value to compare from.</param>
    /// <param name = "right">The value to compare with.</param>
    /// <returns><see langword="true"/> if the left parameter is different compared to the right parameter, otherwise <see langword="false"/> if both are same.</returns>
    public static bool operator !=(Class1 left, Class1 right)
    {
        return !(left == right);
    }
}
```

Typing all of this would've took a while!

Or, instead, click `XML: Add Parameterless Constructor`. Our class now looks like this.

```cs
public class Class1
{
    public string Greeting { get; set; }
        = "Welcome to AddWithXmlDoc!"

    /// <summary>
    /// Initializes a new instance of the <see cref="Class1" /> class.
    /// </summary>
    public Class1()
    {
    }
}
```

# 🧱 Prerequisites
AddWithXmlDoc supports all Visual Studio versions starting from Visual Studio 2017. You should have
Visual Studio versions at least 2017 to use AddWithXmlDoc.

# 📦 Building
You'll have to have Visual Studio workloads `.NET Desktop Development` and `Visual Studio extension development` prior to building AddWithXmlDoc.
After that, open the solution VSAddWithXmlDoc.sln, and click Ctrl+Shift+B in Visual Studio to build the entire solution!

# ❔ Got any questions?
Feel free to create an Issue post on the GitHub Repository if you have any questions, found a bug, or proposing a suggestion!

# 🤗 Author
[winscripter](https://github.com/winscripter)

# 🪪 License
Copyright (c) 2023-2025, winscripter

See the file LICENSE.txt for licensing information.
