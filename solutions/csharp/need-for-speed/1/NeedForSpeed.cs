class RemoteControlCar
{
    private int _distanceDriven = 0;
    public int Battery = 100;
    public int speed,batteryDrain;
    
    public RemoteControlCar (int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => Battery ==0 || batteryDrain > Battery;

    public int DistanceDriven() => _distanceDriven;

    public void Drive()
    {
        if (Battery > 0 && batteryDrain <= Battery) 
        {
            _distanceDriven = _distanceDriven + speed;
            Battery = Battery - batteryDrain;
        }
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50,4);

}

class RaceTrack
{
    private int distance;
    public RaceTrack (int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        //int drives = distance / car.speed;
        int drives = (distance + car.speed - 1) / car.speed;
        int total = drives * car.batteryDrain;
        return car.Battery - total >= 0;
    }
}
