public static class Gigasecond
{
    public static DateTime Add(DateTime moment)
    {
        const int GIGASECOND = 1000000000;

        TimeSpan gigaSpan = TimeSpan.FromSeconds(GIGASECOND);

        return moment + gigaSpan;
    }
}