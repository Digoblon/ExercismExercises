static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        double success = 0;
        if (speed == 0)
        {
            success = 0;
        }
        else if (speed >0 && speed <= 4)
        {
            success = 1;
        }
        else if (speed > 4 && speed <=8)
        {
            success = 0.90;
        }
        else if (speed == 9)
        {
            success = 0.8;
        }
        else if (speed == 10)
        {
            success = 0.77;
        }
        return success;
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        double prodRatePH = 221 * speed * SuccessRate(speed);
        return prodRatePH;
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        int prodRatePM = (int)ProductionRatePerHour(speed) /60;
        return prodRatePM;
    }
}
