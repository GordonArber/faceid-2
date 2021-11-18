using System;
using System.Collections.Generic;

public class FacialFeatures
{
    string EyeColor { get; }
    decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    
    public override bool Equals(object obj)
    {
        if ((obj == null) || ! (GetType() == obj.GetType()))
            return false;

        var newFacialFeatures = (FacialFeatures) obj;
        return  obj.GetHashCode() == GetHashCode() && (EyeColor == newFacialFeatures.EyeColor) && (PhiltrumWidth == newFacialFeatures.PhiltrumWidth);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}

public class Identity
{
    string Email { get; }
    FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    public override bool Equals(object obj)
    {
        if ((obj == null) || ! (GetType() == obj.GetType()))
            return false;
        
        var newIdentity = (Identity) obj;
        
        return obj.GetHashCode() == GetHashCode() && Equals(Email, newIdentity.Email) && Equals(FacialFeatures, newIdentity.FacialFeatures);
    }
    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
    readonly HashSet<Identity> _registry = new();
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity)
    {
        var admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
        return identity.Equals(admin);
    }

    public bool Register(Identity identity)
    {
        if (_registry.Contains(identity)) return false;
        
        _registry.Add(identity);
        return true;

    }
    public bool IsRegistered(Identity identity) => _registry.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => ReferenceEquals(identityA, identityB);
}