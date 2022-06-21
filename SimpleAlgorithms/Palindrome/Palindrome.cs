namespace SimpleAlgorithms.Palindrome;

public static class Palindrome
{
    public static bool Validate(string text)
    {
        int halfOfLength = text.Length / 2;
        int j = text.Length - 1;
        
        for (var i = 0; i < halfOfLength; i++, j--)
        {
            while (text[i] == ' ')
                i++;

            while (text[j] == ' ')
                j--;
            
            if (char.ToLower(text[i]) != char.ToLower(text[j]))
                return false;
        }
        return true;
    }
}