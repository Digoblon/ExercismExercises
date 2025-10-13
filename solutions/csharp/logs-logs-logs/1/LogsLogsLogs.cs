// TODO: define the 'LogLevel' enum
enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
};

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        int index1 = logLine.IndexOf("[");
        int index2 = logLine.IndexOf("]");
        string logStr = logLine.Substring(index1+1,index2-1).ToUpper();
        switch (logStr)
        {
            case "TRC":
                return LogLevel.Trace;
                break;
                
            case "DBG":
                return LogLevel.Debug;
                break;
                
            case "INF":
                return LogLevel.Info;
                break;
                
            case "WRN":
                return LogLevel.Warning;
                break;
                
            case "ERR":
                return LogLevel.Error;
                break;
                
            case "FTL":
                return LogLevel.Fatal;
                break;
                
            default:
                return LogLevel.Unknown;
                break;
        }
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)=> 
        $"{(int)logLevel}:{message}";
}
