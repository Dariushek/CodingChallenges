namespace CSharpFeatures.CSharp11;

public partial class UnitTests
{
    private class TestAttribute
    {
        [Generic<string>("parameter")]
        public string Prop { get; set; } = "val";
        
        [Generic<int>(1)]
        public string Prop2 { get; set; } = "val";

    }
}