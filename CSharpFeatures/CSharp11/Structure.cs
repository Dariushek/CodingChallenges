namespace CSharpFeatures.CSharp11;

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
    public string Description { get; init; } = "Ordinary Structure";

    public override string ToString() => $"{Value} ({Description})";
}