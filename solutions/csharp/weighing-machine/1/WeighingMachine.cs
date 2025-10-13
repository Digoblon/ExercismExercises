class WeighingMachine
{
    // TODO: define the 'Precision' property
    public int Precision { get;  }

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }

    // TODO: define the 'Weight' property
    private double _weight;

    public double Weight
    {
        get {return _weight;}
        set 
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Weight cannot be negative.");

            _weight = value;    
        }
    }

    // TODO: define the 'DisplayWeight' property
    private string _displayWeight;

    public string DisplayWeight
    {
        get
        {
            double result = Weight - TareAdjustment;
            string formatted = Math.Round(result, Precision).ToString($"F{Precision}");
            return $"{formatted} kg";
        }
        
    }   
    
    

    // TODO: define the 'TareAdjustment' property
    public double TareAdjustment { get; set; } = 5.0;
}
