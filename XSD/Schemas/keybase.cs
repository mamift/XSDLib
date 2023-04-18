using System;

namespace W3C.XSD;

public partial class keybase
{
    protected bool Equals(keybase other)
    {
        return Equals(field, other.field) &&
               Equals(selector, other.selector) &&
               Equals(name, other.name);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((keybase) obj);
    }

    public override int GetHashCode() => HashCode.Combine(field, selector, name);
}