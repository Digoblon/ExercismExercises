using System.Text;
public static class RomanNumeralExtension
{
    private static readonly (int Value, string Numeral)[] Numerals = new (int, string)[]
    {
        (1000, "M"),
        (900, "CM"),
        (500, "D"),
        (400, "CD"),
        (100, "C"),
        (90, "XC"),
        (50, "L"),
        (40, "XL"),
        (10, "X"),
        (9, "IX"),
        (5, "V"),
        (4, "IV"),
        (1, "I")
    };
    
    public static string ToRoman(this int number)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException(nameof(number), "Must be positive.");

        var sb = new StringBuilder();

        foreach (var (value, numeral) in Numerals)
        {
            while (number >= value)
            {
                sb.Append(numeral);
                number -= value;
            }
        }

        return sb.ToString();
    }
}
