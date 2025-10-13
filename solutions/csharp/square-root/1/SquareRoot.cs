public static class SquareRoot
{
    public static int? Root(int number)
    {
        int min =1;
        int max = number;

        if(number==0||number==1)
            return number;
        
        while (min <= max)
        {
            int meio = min + (max - min) /2;
            int meioRaiz = meio * meio;

            if (meioRaiz == number)
                return meio;
            else if(meioRaiz < number)
            {
                min = meio + 1;
            }
            else
            {
                max = meio -1;
            }
        }
        return null;
    }
}
