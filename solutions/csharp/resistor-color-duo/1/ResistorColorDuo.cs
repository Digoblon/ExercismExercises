public static class ResistorColorDuo
{
    public static int Value(string[] colors)
    {
        string[] colorsIndex = Colors();
        if (colorsIndex.Length == 1)
            return Array.IndexOf(colorsIndex,colors[0]);
        else
        {
            return int.Parse($"{Array.IndexOf(colorsIndex,colors[0])}{Array.IndexOf(colorsIndex,colors[1])}");
        }
    }

    public static string[] Colors() =>
    new string[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
}
