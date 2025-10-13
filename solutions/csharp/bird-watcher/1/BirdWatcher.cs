class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => new int[] {0,2,5,3,7,8,4};
   /* {
        int[] birdsLastWeek = new[] {0,2,5,3,7,8,4};
        return birdsLastWeek;
    }*/

    public int Today() => birdsPerDay[birdsPerDay.Length -1];
   /* {
        return birdsPerDay[birdsPerDay.Length -1];
    }*/

    public void IncrementTodaysCount()
    {
        int birdsToday = Today();
        birdsPerDay[birdsPerDay.Length -1] = birdsToday +1;
    }

    public bool HasDayWithoutBirds()
    {
        foreach (int birds in birdsPerDay) 
        {

            if(birds == 0)
            {
                return true;
            }
        }
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int totalBirds = 0;
        for (int i = 0;i<numberOfDays;i++)
        {
            totalBirds = totalBirds +  birdsPerDay[i];
        }
        return totalBirds;
    }

    public int BusyDays()
    {
        int _busyDays = 0;
        for (int i = 0;i<birdsPerDay.Length;i++)
        {
            if(birdsPerDay[i] >=5)
            {
                _busyDays++;
            }
        }
        return _busyDays;
    }
}
