using System;
using System.Collections.Generic;
using System.Linq;

namespace W3C.XSD;

public partial class appinfo
{
    protected bool Equals(appinfo other)
    {
        return Equals(source, other.source) &&
               Any.SequenceEqual(other.Any);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((appinfo) obj);
    }

    public override int GetHashCode() => HashCode.Combine(source, source);

    private sealed class appinfoEqualityComparer : IEqualityComparer<appinfo>
    {
        public bool Equals(appinfo x, appinfo y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Equals(y);
        }

        public int GetHashCode(appinfo obj) => HashCode.Combine(obj.source, obj.source);
    }

    public static IEqualityComparer<appinfo> EqualityComparer { get; } = new appinfoEqualityComparer();
}