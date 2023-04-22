using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace W3C.XSD;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public partial class group
{
    protected bool Equals(group other) => Equals(Content, other.Content);

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((group) obj);
    }

    public override int GetHashCode() => HashCode.Combine(Content);

    private sealed class ContentFieldEqualityComparer : IEqualityComparer<group>
    {
        public bool Equals(group x, group y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;

            return Equals(x.Content, y.Content);
        }

        public int GetHashCode(group obj) => HashCode.Combine(obj.Content);
    }

    public static IEqualityComparer<group> ContentFieldComparer { get; } = new ContentFieldEqualityComparer();
}