public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (sliceLength > numbers.Length || sliceLength <= 0) 
            throw new ArgumentException();

        List<string> slices = [];
        int quant = 1;

        quant = quant + numbers.Length - sliceLength;
        
        for (int i = 0; i < quant; i++)
        {
            string slice = numbers.Substring(i,sliceLength);
            slices.Add(slice);
        }

        return slices.ToArray();
    }
}