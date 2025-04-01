using System.Linq;
using System.Threading;
using FluentAssertions;
using Xunit;

namespace Multithreading;

public class Tests
{
    private readonly object incrementingLock = new();

    [Fact]
    public void LockedVariableIncrementedByTwoThreadsHasProperValue()
    {
        var index = 0;

        ThreadStart increment = () =>
        {
            foreach (int _ in Enumerable.Range(1, 10000))
            {
                lock (incrementingLock)
                    index++;
            }
        };

        var thread1 = new Thread(increment);
        var thread2 = new Thread(increment);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        index.Should().Be(20000);
    }

    [Fact]
    public void VariableIncrementedByTwoThreadsHasInvalidValue()
    {
        var index = 0;

        ThreadStart increment = () =>
        {
            foreach (int _ in Enumerable.Range(1, 10000))
                index++;
        };

        var thread1 = new Thread(increment);
        var thread2 = new Thread(increment);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        index.Should().NotBe(20000);
    }
}