using System;

namespace W3C.XSD;

public partial class field
{
    protected bool Equals(field other)
    {
        return Equals(annotation, other.annotation) &&
               Equals(id, other.id) &&
               Equals(xpath, other.xpath);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((field) obj);
    }

    public override int GetHashCode() => HashCode.Combine(annotation, id, xpath);
}