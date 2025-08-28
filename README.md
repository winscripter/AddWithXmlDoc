# 📃 AddWithXmlDoc
[![Shield](https://img.shields.io/badge/NUGET-20B2AA?style=for-the-badge)](https://www.nuget.org/packages/AddWithXmlDoc.Core)
[![Shield](https://img.shields.io/badge/DOWNLOAD-8A2BE2?style=for-the-badge)](https://marketplace.visualstudio.com/items?itemName=winscripter.ExtVSAddWithXmlDoc)

A Visual Studio extension that lets you generate common methods in C# - parameterless constructors, `GetHashCode`, `Equals`, and equality operators - with XML documentation automatically inserted for you.

# ❓ How does it work?
When you install the extension, you get 7 new code actions for classes and structs!

- `XML: Add Equality Methods to Fields`: When you click this, it generates `GetHashCode`, `Equals`, `IEquatable`, and equality operators for all fields, + XML documentation.
- `XML: Add Equality Methods to Properties`: Same as the one above, but for properties.
- `XML: Add Equality Methods to Members`: Same as the one above, but for both Fields and Properties.
- `XML: Add Parameterless Constructor`: Adds an empty constructor without any parameters, with XML documentation
- There's also the three other options: Equality methods, but with `(Use inheritdoc)`. These apply an `<inheritdoc cref="..." />` to methods like GetHashCode, IEquatable.Equals, and object.Equals.

![Screenshot](media/Screenshot%202025-08-28%20133212.png)

You no longer have to manually write XML documentation for methods like `GetHashCode` or `Equals` - even an `<inheritdoc ... />` can take some time to write! AddWithXmlDoc does that for you.

# Installation
Go to the [![Shield](https://img.shields.io/badge/EXTENSION%20IN%20VISUAL%20STUDIO%20MARKETPLACE-8A2BE2?style=for-the-badge)](https://marketplace.visualstudio.com/items?itemName=winscripter.ExtVSAddWithXmlDoc), and click the green "Download" button to get the VSIX.

Double click the VSIX, and that's it! Wait for it to install, and AddWithXmlDoc will be installed on your Visual Studio installation.

# ✨ Example
Imagine we have a class:
```cs
public class Class1
{
    public string Greeting { get; set; }
        = "Welcome to AddWithXmlDoc!"
}
```

Right click on `Class1`. Click `XML: Add Parameterless Constructor`. Our class now looks like this.

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

It also supports generating `GetHashCode()`, `IEquatable.Equals`, `object.Equals`, `==`, and `!=`. Examples of generated code for such methods are documented in the docs. (See below)

# 📄 Docs
See [docs.md](docs/docs.md)

# 🧱 Prerequisites
AddWithXmlDoc supports all Visual Studio versions starting from Visual Studio 2022. You should have
Visual Studio versions at least 2022 to use AddWithXmlDoc.

# 📦 Building
You'll have to have Visual Studio workloads `.NET Desktop Development` and `Visual Studio extension development` prior to building AddWithXmlDoc.
After that, open the solution VSAddWithXmlDoc.sln, and click Ctrl+Shift+B in Visual Studio to build the entire solution!

# ❔ Got any questions?
Feel free to create an Issue post on the GitHub Repository if you have any questions, found a bug, or proposing a suggestion! I will be happy to respond or help.

# ❤️ How can I help?
If you've tried our extension and you'd like to help:
- You can star our GitHub Repository if you like the extension,
- You can give a ★★★★★ rating on the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=winscripter.ExtVSAddWithXmlDoc) if you really like the extension,
- You can recommend the extension to others, like coworkers, friends, or colleagues, if you **really really** like the extension,

We highly appreciate any help, and any form of help means a lot to me.

# 🤗 Author
[winscripter](https://github.com/winscripter)

# 🪪 License
Copyright (c) 2023-2025, winscripter

See the file LICENSE.txt for licensing information.
