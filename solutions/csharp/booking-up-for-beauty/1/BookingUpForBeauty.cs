static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        DateTime dtTime = DateTime.Parse(appointmentDateDescription);
        return dtTime;
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        DateTime dateNow = DateTime.Now;
        return dateNow > appointmentDate;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate) => 
        appointmentDate.Hour >= 12 && appointmentDate.Hour <18;
   

    public static string Description(DateTime appointmentDate) => 
        $"You have an appointment on {appointmentDate.ToString("M/d/yyyy h:mm:ss tt")}.";
    

    public static DateTime AnniversaryDate() 
    {
        DateTime dateNow = DateTime.Now;
        DateTime dateAnniversary = new DateTime(dateNow.Year,9,15);
        return dateAnniversary;
    }
}
