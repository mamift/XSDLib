using System;
using System.Collections.Generic;

namespace W3C.XSD;

public abstract partial class groupType
{
    protected bool Equals(groupType other)
    {
        return Equals(elementField, other.elementField) &&
               Equals(groupField, other.groupField) &&
               Equals(allField, other.allField) &&
               Equals(choiceField, other.choiceField) &&
               Equals(sequenceField, other.sequenceField) &&
               Equals(anyField, other.anyField) &&
               Equals(name, other.name) &&
               Equals(@ref, other.@ref) &&
               Equals(minOccurs, other.minOccurs) &&
               Equals(maxOccurs, other.maxOccurs);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((groupType) obj);
    }

    public override int GetHashCode()
    {
        unchecked {
            var hashCode = (elementField != null ? elementField.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (groupField != null ? groupField.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (allField != null ? allField.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (choiceField != null ? choiceField.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (sequenceField != null ? sequenceField.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (anyField != null ? anyField.GetHashCode() : 0);
            return hashCode ^ HashCode.Combine(name, @ref, minOccurs, maxOccurs);
        }
    }

    private sealed class GroupTypeEqualityComparer : IEqualityComparer<groupType>
    {
        public bool Equals(groupType x, groupType y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Equals(y);
        }

        public int GetHashCode(groupType obj) => obj.GetHashCode();
    }

    public static IEqualityComparer<groupType> GroupTypeComparer { get; } = new GroupTypeEqualityComparer();
}