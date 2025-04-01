namespace CleverSnippets;

public abstract record StringEnumBase(string Value)
{
    public string Value { get; } = Value;

    public override string ToString()
    {
        return Value;
    }
}