public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        int steps = 0;
        if (number <= 0)
            throw new ArgumentOutOfRangeException("number");
        while (number > 1)
            {
                if (int.IsEvenInteger(number))
                {
                    number = number / 2;
                }
                else
                {
                    number = number * 3 + 1;
                }
                steps++;
            }
        return steps;
    }
}