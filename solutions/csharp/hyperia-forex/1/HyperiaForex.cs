public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }


    public static bool operator == (CurrencyAmount a, CurrencyAmount b)
    {
        if(a.currency != b.currency)
        {
            throw new ArgumentException();
        }
        return a.amount == b.amount && a.currency == b.currency;
    }

    public static bool operator != (CurrencyAmount a, CurrencyAmount b) =>
        !(a==b);

    public static bool operator <(CurrencyAmount a, CurrencyAmount b)
    {
        if(a.currency != b.currency)
        {
            throw new ArgumentException();
        }
        return  a.amount < b.amount;            
    }
    
    public static bool operator >(CurrencyAmount a, CurrencyAmount b)
    {
        if(a.currency != b.currency)
        {
            throw new ArgumentException();
        }
        return  a.amount > b.amount;  
    }

    public static decimal operator +(CurrencyAmount a, CurrencyAmount b)
    {
        if(a.currency != b.currency)
        {
            throw new ArgumentException();
        }
        return a.amount + b.amount;
    }

    public static decimal operator -(CurrencyAmount a, CurrencyAmount b)
    {
        if(a.currency != b.currency)
        {
            throw new ArgumentException();
        }
        return a.amount - b.amount;
    }

    public static decimal operator *(CurrencyAmount a, CurrencyAmount b)
    {
        if(a.currency != b.currency)
        {
            throw new ArgumentException();
        }
        return a.amount * b.amount;
    }

    public static decimal operator /(CurrencyAmount a, CurrencyAmount b)
    {
        if(a.currency != b.currency)
        {
            throw new ArgumentException();
        }
        decimal result = 0;
        try
        {
            result = a.amount / b.amount;
        }
        catch (Exception)
        {
            throw;
        }
        return result;
    }
    
    // TODO: implement type conversion operators
    public static explicit operator double (CurrencyAmount a) =>
        (double)a.amount;

    public static implicit operator decimal(CurrencyAmount a) =>
        (decimal)a.amount;
}
