namespace CSharpFeatures.CSharp11Models;

public readonly struct Structure
{
    public Structure(double value)
    {
        Value = value;
    }

    public Structure(double value, string description)
    {
        Value = value;
        Description = description;
    }

    public Structure(string description)
    {
        Description = description;
    }

    public double Value { get; init; }
    public string Description { get; init; }

    public override string ToString() => $"{Value} ({Description})";
}