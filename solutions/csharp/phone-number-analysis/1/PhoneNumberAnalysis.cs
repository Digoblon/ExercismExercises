public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        (bool IsNewYork, bool IsFake, string LocalNumber) phoneAnal;
        phoneAnal.IsNewYork = phoneNumber.Substring(0, 3) == "212";
        phoneAnal.IsFake = phoneNumber.Substring(4,3) == "555";
        phoneAnal.LocalNumber = phoneNumber.Substring(8);
        return phoneAnal;
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
}
