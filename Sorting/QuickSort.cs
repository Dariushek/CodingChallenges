namespace Sorting
{
    public static class QuickSort
    {
        public static int[] Sort(int[] numbers)
        {
            Sort(ref numbers, 0, numbers.Length);

            return numbers;
        }

        private static void Sort(ref int[] numbers, int beginIndex, int length)
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

            Sort(ref numbers, beginIndex, lesserCount);
            Sort(ref numbers, endIndex - greaterCount, greaterCount);
        }
    }

    public static class ArrayExtensions
    {
        public static void Swap(this int[] numbers, int leftPosition, int rightPosition)
        {
            int left = numbers[leftPosition];
            numbers[leftPosition] = numbers[rightPosition];
            numbers[rightPosition] = left;
        }
    }
}