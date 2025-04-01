namespace CSharpFeatures;

public record struct Height(double Value) : IMeasurable<Height>
{
    public static Height operator +(Height left, Height right)
    {
        return new Height(left.Value + right.Value);
    }

    public static Height operator /(Height left, Height right)
    {
        return new Height(left.Value / right.Value);
    }

    public static Height One => new(1);
    public static Height Zero => new(0);
    
    public static T Average<T>(params T[] array) where T : IMeasurable<T> 
    {
        if (array.Length == 0)
            return T.Zero;
    
        var result = T.Zero;
        var denominator = T.Zero;
    
        foreach (var val in array) {
            result += val;
            denominator += T.One;
        }
        return result / denominator;
    }
}


public interface IMeasurable<T> where T : IMeasurable<T>
{
    static abstract T operator +(T left, T right);
    static abstract T operator /(T left, T right);
    static abstract T One { get; }
    static abstract T Zero { get; }
}