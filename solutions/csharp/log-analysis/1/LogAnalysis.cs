public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter (this string str,string delim)
    {
        int index = str.IndexOf(delim);
        return str.Substring(index + delim.Length);
    }

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween (this string str,string delim1,string delim2)
    {
        int index1 = str.IndexOf(delim1);
        int index2 = str.IndexOf(delim2);
        
        return str.Substring(index1 + delim1.Length,index2 - (index1 + delim1.Length)).Trim();
    }
    
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message (this string str)
    {
        int index = str.IndexOf(":");
        
        return str.Substring(index +1).Trim();
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel (this string str)
    {
        int index1 = str.IndexOf("[");
        int index2 = str.IndexOf("]");
        return str.Substring(index1 +1,index2-1);
    }
}