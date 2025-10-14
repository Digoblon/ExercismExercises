public class RemoteControlCar
{
    private int batteryPercentage = 100;
    private int distanceDrivenInMeters = 0;
    private string[] sponsors = new string[0];
    private int latestSerialNum = 0;

    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage -= 10;
            distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors)
    {
        List<string> sponsorList = new List<string>(this.sponsors);
        foreach (string _sponsor in sponsors)
        {
            sponsorList.Add(_sponsor);
        }
        this.sponsors = sponsorList.ToArray();
    }

    public string DisplaySponsor(int sponsorNum) =>
        sponsors[sponsorNum];

    public bool GetTelemetryData(ref int serialNum,
            out int batteryPercentage, out int distanceDrivenInMeters)
    {
        if(serialNum < latestSerialNum)
        {
            serialNum = latestSerialNum;
            distanceDrivenInMeters = -1;
            batteryPercentage = -1;
            return false;
        }
        latestSerialNum = serialNum;
        distanceDrivenInMeters = this.distanceDrivenInMeters;
        batteryPercentage = this.batteryPercentage;
        return true;
    }

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }
}

public class TelemetryClient
{
    private RemoteControlCar car;

    public TelemetryClient(RemoteControlCar car)
    {
        this.car = car;
    }

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        int batteryPercentage,distanceDrivenInMeters;
        
    if(car.GetTelemetryData(ref serialNum, out batteryPercentage, out distanceDrivenInMeters))
        {
            if(distanceDrivenInMeters == 0)
            {
                return "no data";
            }
            double usagePerMeter = (100-batteryPercentage)/distanceDrivenInMeters;
            return $"usage-per-meter={usagePerMeter}";
        }
        else
        {
            return "no data";
        }
    }
}
