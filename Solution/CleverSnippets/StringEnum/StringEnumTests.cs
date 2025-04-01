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
        StringEnum optionA2 = StringEnum.OptionA;
        StringEnum optionB = StringEnum.OptionB;

        testOutputHelper.WriteLine(optionA.ToString());
        testOutputHelper.WriteLine(optionB.ToString());

        optionA.Should().BeEquivalentTo(optionA2);
        optionA.Should().Be(optionA2);

        optionA.Should().NotBe(optionB);
        optionA.Should().NotBeEquivalentTo(optionB);

        (optionA == optionA2).Should().BeTrue();
        (optionA != optionB).Should().BeTrue();
    }
}