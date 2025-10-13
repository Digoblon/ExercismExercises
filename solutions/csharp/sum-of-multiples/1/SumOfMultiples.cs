public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> factors, int max)
    {
        var multiples = new HashSet<int>();

        foreach (var factor in factors)
        {
            if (factor == 0) continue;

            for (int m = factor; m < max; m += factor)
            {
                multiples.Add(m);
            }
        }

        int sum = 0;
        foreach (var num in multiples)
        {
            sum += num;
        }

        return sum;
    }
}