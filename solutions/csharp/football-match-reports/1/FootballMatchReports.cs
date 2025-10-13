public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        string position = shirtNum switch
        {
            1 => "goalie",
            2 => "left back",
            3 or 4 => "center back",
            5 => "right back",
            6 or 7 or 8 => "midfielder",
            9 => "left wing",
            10 => "striker",
            11 => "right wing",
            _ => "UNKNOWN"
        };
        return position;
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case string PA:
                return PA;
                break;
                
            case int sup:
                return $"There are {sup} supporters at the match.";
                break;

            case Injury injury:
                return $"Oh no! {injury.GetDescription()} Medics are on the field.";
                break;

            case Foul foul:
                return foul.GetDescription();

            case Incident inc:
                return inc.GetDescription();
                break;

            case Manager man when man.Club == null:
                return $"{man.Name}";
                break;

            case Manager man:
                return $"{man.Name} ({man.Club})";
                break;

            default:
                return "";
                break;
        }
        return "";
    }
}
