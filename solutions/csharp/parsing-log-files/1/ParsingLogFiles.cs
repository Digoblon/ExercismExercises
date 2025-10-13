using System.Text.RegularExpressions;
public class LogParser
{
    public bool IsValidLine(string text)
    {
        if
        (Regex.IsMatch(text, @"^(?:\[TRC\]|\[DBG\]|\[INF\]|\[WRN\]|\[ERR\]|\[FTL\])"))
        return true;

        return false;
    }

    public string[] SplitLogLine(string text) =>
        Regex.Split(text,@"<[\^*=\-]+>");

    public int CountQuotedPasswords(string lines)
    {
        string pattern = "\"[^\"]*password[^\"]*\"";

        var matches = Regex.Matches(lines, pattern, RegexOptions.IgnoreCase);
    
        return matches.Count;
    }

    public string RemoveEndOfLineText(string line) =>
        Regex.Replace(line,@"end-of-line\d+","");

    public string[] ListLinesWithPasswords(string[] lines)
    {
        var result = new List<string>();
        var regex = new Regex(@"\bpassword\w+\b", RegexOptions.IgnoreCase);
    
        foreach (var line in lines)
        {
            var match = regex.Match(line);
    
            if (match.Success)
            {
                result.Add($"{match.Value}: {line}");
            }
            else
            {
                result.Add($"--------: {line}");
            }
        }
    
        return result.ToArray();
    }
}
