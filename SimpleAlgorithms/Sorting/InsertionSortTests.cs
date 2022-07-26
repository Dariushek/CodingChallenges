using FluentAssertions;
using Xunit;

namespace SimpleAlgorithms.Sorting;

public class InsertionSortTests
{
    [Theory]
    [InlineData(new[] {3, 1, 2, 9})]
    [InlineData(new[] {56, 12, 8, 3, 92})]
    [InlineData(new[] {2, 12, 9, 34, 7, 98})]
    [InlineData(new[] {2, 3})]
    [InlineData(new[] {43})]
    [InlineData(new[] {3, 2, 1})]
    public void InsertionSortTakingUnsortedArrayReturnsSorted(int[] numbers)
    {
        int[] sorted = InsertionSort.Sort(numbers);

        sorted.Should().BeInAscendingOrder();
    }
}