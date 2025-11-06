public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
{
    if (number <= 0)
        throw new ArgumentOutOfRangeException();

    int soma = 1; // 1 sempre é divisor, exceto do próprio 1
    int limite = (int)Math.Sqrt(number);

    for (int i = 2; i <= limite; i++)
    {
        if (number % i == 0)
        {
            int outroDivisor = number / i;

            if (i != outroDivisor)
                soma += i + outroDivisor; // soma o par
            else
                soma += i; // caso de quadrado perfeito (ex: 16 -> 4 * 4)
        }
    }

    if (number == 1)
        soma = 0; // o 1 não tem divisores próprios

    if (soma == number)
        return Classification.Perfect;
    else if (soma > number)
        return Classification.Abundant;
    else
        return Classification.Deficient;
}
}
