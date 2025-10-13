using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) =>
        dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
{
    string timeZoneId;

    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    {
        switch (location)
        {
            case Location.NewYork:
                timeZoneId = "Eastern Standard Time";
                break;
            case Location.London:
                timeZoneId = "GMT Standard Time";
                break;
            case Location.Paris:
                timeZoneId = "W. Europe Standard Time";
                break;
            default:
                throw new ArgumentException("Local inválido", nameof(location));
        }
    }
    else // Linux ou Mac
    {
        switch (location)
        {
            case Location.NewYork:
                timeZoneId = "America/New_York";
                break;
            case Location.London:
                timeZoneId = "Europe/London";
                break;
            case Location.Paris:
                timeZoneId = "Europe/Paris";
                break;
            default:
                throw new ArgumentException("Local inválido", nameof(location));
        }
    }

    TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

    string format = "M/d/yyyy HH:mm:ss";
    DateTime dt = DateTime.ParseExact(appointmentDateDescription, format, CultureInfo.InvariantCulture);

    // marcar como horário "local do salão"
    dt = DateTime.SpecifyKind(dt, DateTimeKind.Unspecified);

    // converter para UTC
    return TimeZoneInfo.ConvertTimeToUtc(dt, tz);
}

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        DateTime dtAlert = appointment;
        switch (alertLevel)
        {
            case AlertLevel.Early:
                dtAlert = appointment.AddHours(-24);
                break;

            case AlertLevel.Standard:
                dtAlert = appointment.AddMinutes(-105);
                break;

            case AlertLevel.Late:
                dtAlert = appointment.AddMinutes(-30);
                break;
        }
        return dtAlert;
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {

        string timeZoneId;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            switch (location)
            {
                case Location.NewYork:
                    timeZoneId = "Eastern Standard Time";
                    break;

                case Location.London:
                    timeZoneId = "GMT Standard Time";
                    break;

                case Location.Paris:
                    timeZoneId = "W. Europe Standard Time";
                    break;

                default:
                    timeZoneId = "";
                    break;
            }
        else

            switch (location)
            {            
                case Location.NewYork:
                    timeZoneId = "America/New_York";
                    break;

                case Location.London:
                    timeZoneId = "Europe/London";
                    break;

                case Location.Paris:
                    timeZoneId = "Europe/Paris";
                    break;

                default:
                    timeZoneId = "";
                    break;
            }

        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

        DateTime dtTimeZone = TimeZoneInfo.ConvertTime(dt, tz);

        DateTime dtAntes = dt.AddDays(-7);

        bool nowDst = tz.IsDaylightSavingTime(TimeZoneInfo.ConvertTime(dtTimeZone, tz));
        bool pastDst = tz.IsDaylightSavingTime(TimeZoneInfo.ConvertTime(dtAntes, tz));

        return nowDst != pastDst;

        
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        CultureInfo culture;

        switch (location)
        {
            case Location.NewYork:
                culture = new CultureInfo("en-US"); // formato padrão: MM/dd/yyyy
                break;

            case Location.London:
                culture = new CultureInfo("en-GB"); // formato padrão: dd/MM/yyyy
                break;

            case Location.Paris:
                culture = new CultureInfo("fr-FR"); // formato padrão: dd/MM/yyyy HH:mm
                break;

            default:
                culture = CultureInfo.InvariantCulture;
                break;
        }

        if (DateTime.TryParse(dtStr, culture, DateTimeStyles.None, out DateTime result))
        {
            return result;
        }
        else
        {
            return DateTime.MinValue; // retorna 1/1/0001 se falhar
        }
    }
}
