public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;

        if (obj is FacialFeatures other)
        {
            return this.EyeColor == other.EyeColor &&
                   this.PhiltrumWidth == other.PhiltrumWidth;
        }

        return false;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor,PhiltrumWidth);
    }

}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    
     public override bool Equals(object obj)
    {
        if (obj == null) return false;

        if (obj is Identity other)
        {
            if((this.Email == other.Email)&&(this.FacialFeatures.Equals(other.FacialFeatures)))
                return true;
         }
        return false;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Email,FacialFeatures);
    }
}

public class Authenticator
{
    private HashSet<Identity> _registrados = new HashSet<Identity>();
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) =>
        faceA.Equals(faceB);

    public bool IsAdmin(Identity identity)
    {
        Identity admin = new Identity("admin@exerc.ism",new FacialFeatures("green", 0.9m));
        return identity.Equals(admin);
    }

    public bool Register(Identity identity) =>
        _registrados.Add(identity);

    public bool IsRegistered(Identity identity) =>
        _registrados.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) =>
        identityA == identityB;
}
