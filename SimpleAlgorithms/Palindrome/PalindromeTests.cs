using FluentAssertions;
using Xunit;

namespace SimpleAlgorithms.Palindrome;

public class PalindromeTests
{
    [Theory]
    [InlineData("level")]
    [InlineData("kayak")]
    [InlineData("noon")]
    [InlineData("RaceCar")]
    public void ValidatePalindromeValidatesSingleWordsCorrectly(string word)
    {
        Palindrome.Validate(word).Should().Be(true);
    }
}