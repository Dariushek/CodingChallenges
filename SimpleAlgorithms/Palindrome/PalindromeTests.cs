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
    
    [Theory]
    [InlineData("taco cat")]
    [InlineData("red rum sir is murder")]
    [InlineData("no lemon no melon")]
    public void ValidatePalindromeValidatesMultipleWordsCorrectly(string text)
    {
        Palindrome.Validate(text).Should().Be(true);
    }
}