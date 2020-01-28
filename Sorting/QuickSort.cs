using System.Linq;

namespace Sorting
{
    public static class QuickSort
    {
        public static int[] Sort(int[] numbers)
        {
            int[] numbersCopy = numbers.ToArray();
            Sort(numbersCopy, 0, numbers.Length);

            return numbersCopy;
        }

        private static void Sort(int[] numbers, int beginIndex, int length)
        {
            if (length < 2)
                return;

            int endIndex = beginIndex + length;
            int lesserCount = 0;
            int greaterCount = 0;

            for (int index = beginIndex + 1; index < endIndex; index++)
            {
                if (numbers[index] < numbers[beginIndex])
                {
                    if (greaterCount > 0)
                    {
                        numbers.Swap(beginIndex + lesserCount + 1, index);
                    }

                    lesserCount++;
                }
                else
                {
                    greaterCount++;
                }
            }

            numbers.Swap(beginIndex + lesserCount, beginIndex);

            Sort(numbers, beginIndex, lesserCount);
            Sort(numbers, endIndex - greaterCount, greaterCount);
        }

        public static void Swap(this int[] numbers, int leftPosition, int rightPosition)
        {
            int left = numbers[leftPosition];
            numbers[leftPosition] = numbers[rightPosition];
            numbers[rightPosition] = left;
        }
    }
}