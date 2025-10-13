static class LogLine
{
    public static string Message(string logLine)
    {
        int index = logLine.IndexOf(":");
        
        return logLine.Substring(index + 1).Trim();
    }

    public static string LogLevel(string logLine)
    {
        int index1 = logLine.IndexOf("[");
        int index2 = logLine.IndexOf("]");

        return logLine.Substring(index1+1,index2-1).ToLower();
    }

    public static string Reformat(string logLine)
    {
        int index1 = logLine.IndexOf("[");
        int index2 = logLine.IndexOf("]");
        string level  = logLine.Substring(index1+1,index2-1).ToLower();

        int index = logLine.IndexOf(":");
        
        string msg = logLine.Substring(index+1).Trim(); 

        return msg + " (" + level + ")";
    }
}
