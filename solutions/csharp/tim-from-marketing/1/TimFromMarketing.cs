static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string returnString = name;
        if (id != null)
        {
            returnString = $"[{id}] - {returnString}";
        }
        if (department == null)
        {
            return $"{returnString} - OWNER";
        }
        else 
        {
            return $"{returnString} - " + department.ToUpper();
        }
    }
}
