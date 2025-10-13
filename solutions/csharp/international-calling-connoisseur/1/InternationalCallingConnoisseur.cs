public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary() =>
        new Dictionary<int,string>();

    public static Dictionary<int, string> GetExistingDictionary()
    {
        var dict = new Dictionary<int,string>
        {
            {1,"United States of America"},
            {55,"Brazil"},
            {91,"India"}
        };
        return dict;
    }

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        return new Dictionary<int,string>
        {
            {countryCode,countryName}
        };
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary.Add(countryCode,countryName);
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode) =>
        existingDictionary.ContainsKey(countryCode)?existingDictionary[countryCode]:string.Empty;

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode) => 
        existingDictionary.ContainsKey(countryCode);

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if (existingDictionary.ContainsKey(countryCode))
            existingDictionary[countryCode] = countryName;
        return existingDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if (existingDictionary.ContainsKey(countryCode))
            existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        int nomeLongo = 0;
        string nomePais = "";
        foreach (string pais in existingDictionary.Values)
        {
            if(pais.Length > nomeLongo)
            {
                nomeLongo = pais.Length;
                nomePais = pais;
            }
        }
        return nomePais;
    }
}