using FluentAssertions;
using Xunit.Abstractions;

namespace CleverSnippets;

public class StringEnumTests
{
    private readonly ITestOutputHelper testOutputHelper;

    public StringEnumTests(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test()
    {
        StringEnum optionA = StringEnum.OptionA;
        StringEnum optionAa = StringEnum.OptionA;
        StringEnum optionB = StringEnum.OptionB;

        testOutputHelper.WriteLine(optionA.ToString());
        testOutputHelper.WriteLine(optionB.ToString());

        optionA.Should().BeEquivalentTo(optionAa);
        optionA.Should().Be(optionAa);
        
        optionA.Should().NotBe(optionB);
        optionA.Should().NotBeEquivalentTo(optionB);
        
        (optionA == optionAa).Should().BeTrue();
        (optionA != optionB).Should().BeTrue();
    }
}

public sealed record StringEnum
{
    private const string OptionAValue = "A";
    private const string OptionBValue = "B";
    public static readonly StringEnum OptionA = new(OptionAValue);
    public static readonly StringEnum OptionB = new(OptionBValue);

    private StringEnum(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public override string ToString()
    {
        return Value;
    }
}