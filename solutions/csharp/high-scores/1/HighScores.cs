using System;
public class HighScores
{
    private List<int> scores;

    public HighScores(List<int> list)
    {
        this.scores = list;
    }

    public List<int> Scores() => scores;

    public int Latest() => scores[scores.Count - 1];

   public int PersonalBest() =>
        scores.Max();


    public List<int> PersonalTopThree() =>
        scores.OrderByDescending(s => s).Take(3).ToList();

}