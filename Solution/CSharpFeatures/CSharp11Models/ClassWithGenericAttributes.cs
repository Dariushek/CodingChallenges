namespace CSharpFeatures.CSharp11Models;

public class ClassWithGenericAttributes
{
    [Generic<string>("parameter")]
    public string Prop { get; set; } = "val";
        
    [Generic<int>(1)]
    public string Prop2 { get; set; } = "val";

}

public class GenericAttribute<T> : Attribute
{
    public GenericAttribute(T param)
    {
        Param = param;
    }

    public T Param { get; }
}