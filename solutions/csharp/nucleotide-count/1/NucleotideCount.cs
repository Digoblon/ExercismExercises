public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        int A = 0;
        int C = 0;
        int G = 0;
        int T = 0;
        //int invalid = 0;
        foreach (char nucleo in sequence)
        {
            switch (nucleo)
            {
                case 'A':
                    A++;
                    break;

                case 'C':
                    C++;
                    break;

                case 'G':
                    G++;
                    break;
    
                case 'T':
                    T++;
                    break;

                default:
                    throw new ArgumentException("Invalid Sequence");
                    break;
            }
        }
        return new Dictionary<char, int>
        {
        { 'A', A }, { 'C', C }, { 'G', G },{'T',T }
        };
    }
}