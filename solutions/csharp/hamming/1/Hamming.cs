public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        char[] charFirstStrand = firstStrand.ToCharArray();
        char[] charSecondStrand = secondStrand.ToCharArray();
        int hammingCount = 0;
        if(charFirstStrand.Length == charSecondStrand.Length)
        {
            for (int i = 0; i < charFirstStrand.Length; i++)
            {
                if (charFirstStrand[i] != charSecondStrand[i])
                    hammingCount++;
            }
        }
        else
        {
            throw (new ArgumentException());
        }

        return hammingCount;
    }
}