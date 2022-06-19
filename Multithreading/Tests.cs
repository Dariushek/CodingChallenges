using System;
using System.Linq;
using System.Threading;
using FluentAssertions;
using Xunit;

namespace Multithreading
{
    public class Tests
    {
        private readonly object incrementingLock = new object();
        [Fact]
        public void LockedVariableIncrementedByTwoThreadsHasProperValue()
        {
            int i = 0;

            ThreadStart increment = () =>
            {
                foreach (int _ in Enumerable.Range(1,10000))
                {
                    lock (incrementingLock)
                    {
                        i++;
                    }
                }
            };
            
            var thread1 = new Thread(increment);
            var thread2 = new Thread(increment);
            
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            i.Should().Be(20000);
        }
    }
}