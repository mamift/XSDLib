using System;
using System.Collections.Generic;

namespace W3C.XSD;

public partial class sequence
{
    protected bool Equals(sequence other)
    {
        return Equals(Content, other.Content);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((sequence) obj);
    }

    public override int GetHashCode() => HashCode.Combine(Content);

    private sealed class sequenceEqualityComparer : IEqualityComparer<sequence>
    {
        public bool Equals(sequence x, sequence y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return Equals(x.Content, y.Content);
        }

        public int GetHashCode(sequence obj) => obj.GetHashCode();
    }

    public static IEqualityComparer<sequence> EqualityComparer { get; } = new sequenceEqualityComparer();
}