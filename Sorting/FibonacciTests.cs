using FluentAssertions;
using Xunit;

namespace Sorting
{
    public class FibonacciTests
    {
        [Fact]
        public void Test()
        {
            Fibonacci.ElementAt(0).Should().Be(0);
            Fibonacci.ElementAt(1).Should().Be(1);
            Fibonacci.ElementAt(7).Should().Be(13);
            Fibonacci.ElementAt(12).Should().Be(144);
            Fibonacci.ElementAt(19).Should().Be(4181);
        }
    }

    public static class Fibonacci
    {
        public static int ElementAt(int n) => n switch
        {
            0 => 0,
            1 => 1,
            var number when number > 1 => ElementAt(n -1) + ElementAt(n -2)
        };
    }
}