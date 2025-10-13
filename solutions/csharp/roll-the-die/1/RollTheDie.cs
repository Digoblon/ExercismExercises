public class Player
{
    public int RollDie()
    {
        Random rnd = new System.Random();
        int d18 = rnd.Next(1,18);
        return d18;
    }

    public double GenerateSpellStrength()
    {
        Random rnd = new System.Random();
        double spellStr = rnd.NextDouble()*100;
        return spellStr;
    }
}
