namespace CSharpFeatures.CSharp11;

public class GenericAttribute<T> : Attribute
{
    public GenericAttribute(T param)
    {
        Param = param;
    }

    private T Param { get; }
}