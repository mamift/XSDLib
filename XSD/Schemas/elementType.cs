using System;
using System.Collections.Generic;

namespace W3C.XSD;

public abstract partial class elementType
{
    protected bool Equals(elementType other)
    {
        return Equals(unique, other.unique) &&
               Equals(key, other.key) &&
               Equals(keyref, other.keyref);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((elementType) obj);
    }

    public override int GetHashCode() => HashCode.Combine(unique, key, keyref);

    private sealed class elementTypeEqualityComparer : IEqualityComparer<elementType>
    {
        public bool Equals(elementType x, elementType y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return Equals(x.unique, y.unique) && Equals(x.key, y.key) && Equals(x.keyref, y.keyref);
        }

        public int GetHashCode(elementType obj) => HashCode.Combine(obj.unique, obj.key, obj.keyref);
    }

    public static IEqualityComparer<elementType> EqualityComparer { get; } = new elementTypeEqualityComparer();
}