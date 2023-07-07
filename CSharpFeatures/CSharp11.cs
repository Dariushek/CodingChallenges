using CSharpFeatures.CSharp11Models;
using FluentAssertions;

namespace CSharpFeatures;

public class CSharp11
{
    private readonly ITestOutputHelper testOutputHelper;
    public CSharp11(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void RawStringLiterals()
    {
        //raw string literal is delimited by at least three double-quotes
        var raw1 = """This\is\all "content"!""";
        testOutputHelper.WriteLine(raw1);
        var raw2 = """""I can do ", "", """ or even """" double quotes!""""";
        testOutputHelper.WriteLine(raw2);
        var raw3 = """
            <element attr="content">
            <body>
                This line is indented by 4 spaces.
            </body>
            </element>
            """;
        testOutputHelper.WriteLine(raw3);
    }

    [Fact]
    public void ListPatterns()
    {
        int ListPatternMatching(int[] values)
            => values switch
            {
                [2, 9] => 1,
                [2, 9, .., 11] => 2,
                [2, _] => 3,
                [2, ..] => 4,
                [..] => 5
            };
        
        testOutputHelper.WriteLine(ListPatternMatching(new[] { 2, 9 }).ToString()); //1
        testOutputHelper.WriteLine(ListPatternMatching(new[] { 2, 9, 11 }).ToString()); // 2
        testOutputHelper.WriteLine(ListPatternMatching(new[] { 2, 9, 11, 33 }).ToString()); // 4
        testOutputHelper.WriteLine(ListPatternMatching(new[] { 2, 33 }).ToString()); // 3
        testOutputHelper.WriteLine(ListPatternMatching(new[] {2, 33, 111}).ToString()); // 4
        testOutputHelper.WriteLine(ListPatternMatching(new[] { 33, 66, 111 }).ToString()); // 5
    }

    [Fact]
    public void RequiredMembers()
    {
        //var person = new Person { FirstName = "Ada" }; // Error: no LastName!
        var person = new Person { FirstName = "Ada", LastName = "Lovelace"};
    }

    [Fact]
    public void GenericAttribute()
    {
        object[] attributes = typeof(ClassWithGenericAttributes)
            .GetProperties()
            .SelectMany(info => info.GetCustomAttributes(false))
            .ToArray();
        
        var stringAttribute = (GenericAttribute<string>)attributes[0];
        var intAttribute = (GenericAttribute<int>)attributes[1];
        
        stringAttribute.Param.Should().Be("parameter");
        intAttribute.Param.Should().Be(1);
    }

    [Fact]
    public void AutoDefaultStruct()
    {
        // It initializes any fields and auto-properties that are not set based on definite assignment rules,
        // and assigns the default value to them (zero to double and null to string).
        var structure = new Structure();
        testOutputHelper.WriteLine(structure.ToString());
    }
}