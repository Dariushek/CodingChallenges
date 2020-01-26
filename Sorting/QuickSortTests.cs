using System;
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

        private static void Sort(ref int[] numbers, int beginIndex, int length)
        {
            if (length <= 1)
                return;


            int endIndex = beginIndex + length;
            int lesserCount = 0;
            int greaterCount = 0;
            int tempNumber;

            for (var i = beginIndex + 1; i < endIndex; i++)
            {
                if (greaterCount > 0)
                {
                    if (numbers[i] < numbers[beginIndex])
                    {
                        tempNumber = numbers[beginIndex + lesserCount + 1];
                        numbers[beginIndex + lesserCount + 1] = numbers[i];
                        numbers[i] = tempNumber;
                    }

                    ++lesserCount;
                }
                else
                {
                    ++greaterCount;
                }
            }

            tempNumber = numbers[beginIndex + lesserCount];
            numbers[beginIndex + lesserCount] = numbers[beginIndex];
            numbers[beginIndex] = tempNumber;
            //{ 56, 12, 8, 3, 92 }
            Sort(ref numbers, beginIndex, lesserCount);
            Sort(ref numbers, endIndex - greaterCount, greaterCount);
        }
    }
}