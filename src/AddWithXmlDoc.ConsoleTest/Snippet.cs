namespace AddWithXmlDoc.ConsoleTest;

internal static class Snippets
{
    public const string Snippet =
        """
        public sealed class MyClass {
            public string MyProperty { get; set; } = "Hello!";
            private int myField;
            public int MyIntProperty => 5;
        }
        """;
}