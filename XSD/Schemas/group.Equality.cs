using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace W3C.XSD;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public partial class group
{
    protected bool Equals(group other) => Equals(ContentField, other.ContentField);

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((group) obj);
    }

    public override int GetHashCode() => (ContentField != null ? ContentField.GetHashCode() : 0);

    private sealed class ContentFieldEqualityComparer : IEqualityComparer<group>
    {
        public bool Equals(group x, group y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;

            return Equals(x.ContentField, y.ContentField);
        }

        public int GetHashCode(group obj)
        {
            return (obj.ContentField != null ? obj.ContentField.GetHashCode() : 0);
        }
    }

    public static IEqualityComparer<group> ContentFieldComparer { get; } = new ContentFieldEqualityComparer();
}