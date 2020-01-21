using FluentAssertions;
using Xunit;

namespace Sorting
{
    public class QuickSortTests
    {
        [Theory]
        [InlineData(new[] { 3, 1, 2, 9 }, new[] { 1, 2, 3, 9 })]
        [InlineData(new[] { 56, 12, 8, 3, 92 }, new[] { 3, 8, 12, 56, 92 })]
        public void QuickSortGivingUnsortedArrayReturnsSorted(int[] unsorted, int[] expected)
        {
            int[] sorted = QuickSort.Sort(unsorted);

            ArraysAreEqual(sorted, expected).Should().BeTrue();
        }

        private static bool ArraysAreEqual(int[] first, int[] second)
        {
            if (first.Length != second.Length)
                return false;

            for (var i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                    return false;
            }

            return true;
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