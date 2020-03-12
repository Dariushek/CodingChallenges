using System;
using FluentAssertions;
using Xunit;

namespace SimpleAlgorithms.Fibonacci
{
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

    public static class FibonacciSequence
    {
        public static int ElementAt(int n) => n switch
        {
            0 => 0,
            1 => 1,
            var number when number > 1 => ElementAt(n -1) + ElementAt(n -2),
            _ => throw new  ArgumentException()
        };

        public static bool IsSequenceElement(int possibleElement)
        {
            var i = 0;

            while (true)
            {
                if (ElementAt(i) == possibleElement)
                {
                    return true;
                }

                if (ElementAt(i) < possibleElement)
                {
                    i++;
                }
                else
                {
                    break;
                }
            }
            return false;
        }
    }
}