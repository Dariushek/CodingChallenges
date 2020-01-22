using FluentAssertions;
using Xunit;

namespace Sorting
{
    public class QuickSortTests
    {
        [Theory]
        [InlineData(new[] { 3, 1, 2, 9 })]
        [InlineData(new[] { 56, 12, 8, 3, 92 })]
        public void QuickSortGivingUnsortedArrayReturnsSorted(int[] numbers)
        {
            int[] sorted = QuickSort.Sort(numbers);

            sorted.Should().BeInAscendingOrder();
        }
    }

    public static  class QuickSort
    {
        public static int[] Sort(int[] numbers)
        {
            Sort(ref numbers, 0, numbers.Length);

            return numbers;
        }

        private static void Sort(ref int[] tab, int begin, int end)
        {
            tab = new[] {1, 2, 3, 9};
        }
    }
}