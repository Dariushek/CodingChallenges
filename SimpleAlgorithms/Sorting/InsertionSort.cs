namespace SimpleAlgorithms.Sorting;

public static class InsertionSort
{
    public static int[] Sort(int[] numbers)
    {
        if (numbers.Length <= 1)
            return numbers;
        
        for (var i = 1; i < numbers.Length; i++)
        {
            int key = numbers[i];

            for (int j = i; j > 0; j--)
            {
                if (numbers[j - 1] <= numbers[j])
                    continue;
                
                numbers[j] = numbers[j-1];
                numbers[j - 1] = key;
            }
        }

        return numbers;
    }
}