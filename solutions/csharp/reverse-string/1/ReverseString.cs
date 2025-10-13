public static class ReverseString
{
    public static string Reverse(string input)
    {
        char[] palavra = input.ToCharArray();
        char[] palavraReversa = new char[palavra.Length];
        int j = palavra.Length -1;
        for(int i = 0;j>=0;i++)
        {
            palavraReversa[i] = palavra[j];
            j--;
        }
        string output = new string(palavraReversa);
        return output;
    }
}