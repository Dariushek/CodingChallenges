using FluentAssertions;
using Xunit;

namespace SimpleAlgorithms.Fibonacci
{
    public class FibonacciTests
    {
        [Fact]
        public void Test()
        {
            FibonacciSequence.ElementAt(0).Should().Be(0);
            FibonacciSequence.ElementAt(1).Should().Be(1);
            FibonacciSequence.ElementAt(7).Should().Be(13);
            FibonacciSequence.ElementAt(12).Should().Be(144);
            FibonacciSequence.ElementAt(19).Should().Be(4181);
        }
    }

    public static class FibonacciSequence
    {
        public static int ElementAt(int n) => n switch
        {
            0 => 0,
            1 => 1,
            var number when number > 1 => ElementAt(n -1) + ElementAt(n -2)
        };
    }
}