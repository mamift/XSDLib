using System;

namespace W3C.XSD;

public partial class annotation
{
    protected bool Equals(annotation other)
    {
        return Equals(appinfo, other.appinfo) &&
               Equals(documentation, other.documentation) &&
               Equals(id, other.id);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((annotation) obj);
    }

    public override int GetHashCode() => HashCode.Combine(appinfo, documentation, id);
}