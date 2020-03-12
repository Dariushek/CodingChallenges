using System.Linq;

namespace SimpleAlgorithms.Sorting
{
    public static class BubbleSort
    {
        public static int[] Sort(int[] numbers)
        {
            int[] numbersCopy = numbers.ToArray();
            Execute(numbersCopy);
            return numbersCopy;
        }

        private static void Execute(int[] numbers)
        {
            int remainingIterations = numbers.Length;

            while (remainingIterations > 1)
            {
                for (var i = 0; i < remainingIterations - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        numbers.Swap(i, i + 1);
                    }
                }

                remainingIterations--;
            }
        }
    }
}