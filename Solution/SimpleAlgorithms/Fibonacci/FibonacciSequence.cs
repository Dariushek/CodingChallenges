using System;

namespace SimpleAlgorithms.Fibonacci;

public static class FibonacciSequence
{
    public static int ElementAt(int n)
    {
        return n switch
        {
            0 => 0,
            1 => 1,
            var number when number > 1 => ElementAt(n - 1) + ElementAt(n - 2),
            _ => throw new ArgumentException()
        };
    }

    public static bool IsSequenceElement(int possibleElement)
    {
        var i = 0;

        while (true)
        {
            if (ElementAt(i) == possibleElement)
                return true;

            if (ElementAt(i) < possibleElement)
                i++;
            else
                break;
        }

        return false;
    }
}