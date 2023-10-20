namespace CleverSnippets;

public sealed record StringEnum : StringEnumBase
{
    public static readonly StringEnum OptionA = new(string.Intern("A"));
    public static readonly StringEnum OptionB = new(string.Intern("B"));

    private StringEnum(string value) : base(value) { }
}