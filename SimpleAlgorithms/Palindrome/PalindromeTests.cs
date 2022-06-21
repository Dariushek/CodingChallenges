using FluentAssertions;
using Xunit;

namespace SimpleAlgorithms.Palindrome;

public class PalindromeTests
{
    [Theory]
    [InlineData("level", true)]
    [InlineData("kayak", true)]
    [InlineData("noon", true)]
    [InlineData("RaceCar", true)]
    [InlineData("RacerCar", false)]
    [InlineData("civil", false)]
    public void ValidatePalindromeValidatesSingleWordsCorrectly(string word, bool isValid)
    {
        Palindrome.Validate(word).Should().Be(isValid);
    }
    
    [Theory]
    [InlineData("taco cat")]
    [InlineData("red rum sir is murder")]
    [InlineData("no lemon no melon")]
    [InlineData("                        no lemon no melon")]
    [InlineData("        no   lemon      no     mel on")]
    [InlineData("   no l   emon  no me lon    ")]
    public void ValidatePalindromeValidatesMultipleWordsCorrectly(string text)
    {
        Palindrome.Validate(text).Should().Be(true);
    }
    
    [Theory]
    [InlineData("Eva, can I see bees in a cave?")]
    [InlineData("Sit on a potato pan, Otis.")]
    [InlineData("Able was I, ere I saw Elba.")]
    public void ValidatePalindromeIgnoresInsignificantCharacters(string text)
    {
        Palindrome.Validate(text).Should().Be(true);
    }
}