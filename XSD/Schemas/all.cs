using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace W3C.XSD;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public partial class all
{
    protected bool Equals(all other) => Equals(Content, other.Content);

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((all) obj);
    }

    public override int GetHashCode() => HashCode.Combine(Content);

    private sealed class allContentEqualityComparer : IEqualityComparer<all>
    {
        public bool Equals(all x, all y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return Equals(x.Content, y.Content);
        }

        public int GetHashCode(all obj) => obj.GetHashCode();
    }

    public static IEqualityComparer<all> EqualityComparer { get; } = new allContentEqualityComparer();
}