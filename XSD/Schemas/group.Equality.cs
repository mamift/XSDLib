using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace W3C.XSD;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public partial class group
{
    private sealed class ContentFieldEqualityComparer : IEqualityComparer<group>
    {
        public bool Equals(group x, group y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;

            throw new NotImplementedException($"No equality members defined for {nameof(namedGroup)}");

            return Equals(x.ContentField, y.ContentField);
        }

        public int GetHashCode(group obj)
        {
            return (obj.ContentField != null ? obj.ContentField.GetHashCode() : 0);
        }
    }

    public static IEqualityComparer<group> ContentFieldComparer { get; } = new ContentFieldEqualityComparer();
}