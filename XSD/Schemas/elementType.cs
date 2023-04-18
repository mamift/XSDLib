using System;

namespace W3C.XSD;

public abstract partial class elementType
{
    protected bool Equals(elementType other)
    {
        return Equals(unique, other.unique) && Equals(key, other.key) && Equals(keyref, other.keyref);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((elementType) obj);
    }

    public override int GetHashCode() => HashCode.Combine(unique, key, keyref);
}