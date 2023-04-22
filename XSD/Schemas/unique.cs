using System;

namespace W3C.XSD;

public partial class unique
{
    protected bool Equals(unique other)
    {
        return Equals(Content, other.Content) &&
               Equals(field, other.field) &&
               Equals(name, other.name) &&
               Equals(selector, other.selector);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((unique) obj);
    }

    public override int GetHashCode() => HashCode.Combine(Content, field, name, selector);
}