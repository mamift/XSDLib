using System;
using System.Collections.Generic;

namespace W3C.XSD;

public partial class choice
{
    protected bool Equals(choice other) => Equals(Content, other.Content);

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((choice) obj);
    }

    public override int GetHashCode() => HashCode.Combine(Content);

    private sealed class choiceContentEqualityComparer : IEqualityComparer<choice>
    {
        public bool Equals(choice x, choice y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return Equals(x.Content, y.Content);
        }

        public int GetHashCode(choice obj) => obj.GetHashCode();
    }

    public static IEqualityComparer<choice> EqualityComparer { get; } = new choiceContentEqualityComparer();
}