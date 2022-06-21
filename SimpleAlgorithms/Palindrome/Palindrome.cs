namespace SimpleAlgorithms.Palindrome;

public static class Palindrome
{
    public static bool Validate(string word)
    {
        int half = word.Length / 2;
        int j = word.Length - 1;
        for (var i = 0; i < half; i++, j--)
        {
            if (char.ToLower(word[i]) != char.ToLower(word[j]))
                return false;
        }

        return true;
    }
}