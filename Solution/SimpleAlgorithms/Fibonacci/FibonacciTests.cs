using FluentAssertions;
using Xunit;

namespace SimpleAlgorithms.Fibonacci;

public class FibonacciTests
{
    [Fact]
    public void ElementAtReturnsNthElementOfSequence()
    {
        FibonacciSequence.ElementAt(0).Should().Be(0);
        FibonacciSequence.ElementAt(1).Should().Be(1);
        FibonacciSequence.ElementAt(7).Should().Be(13);
        FibonacciSequence.ElementAt(12).Should().Be(144);
        FibonacciSequence.ElementAt(19).Should().Be(4181);
    }

    [Fact]
    public void IsSequenceElementReturnsWhetherElementBelongsToSequence()
    {
        FibonacciSequence.IsSequenceElement(9).Should().Be(false);
        FibonacciSequence.IsSequenceElement(501).Should().Be(false);
        FibonacciSequence.IsSequenceElement(0).Should().Be(true);
        FibonacciSequence.IsSequenceElement(144).Should().Be(true);
        FibonacciSequence.IsSequenceElement(1597).Should().Be(true);
    }
}