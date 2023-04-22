using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using Xml.Schema.Linq;

namespace W3C.XSD.Extensions;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public static partial class IListExtensions
{
    public static bool AddIfNotExists<T>(this IList<T> list, T thing, IEqualityComparer<T> equalityComparer)
        where T: XTypedElement
    {
        var possibleExisting = list.FirstOrDefault(e => {
            var wasEqual = equalityComparer.Equals(e, thing);
            return wasEqual;
        });

        if (possibleExisting == default(T)) {
            list.Add(thing);
            return true;
        }

        return false;
    }

    public static void AddRange<T>(this IList<T> list, IEnumerable<T> others)
        where T: XTypedElement
    {
        foreach (var other in others) {
            list.Add(other);
        }
    }

    public static IList<T> Merge<T>(this IList<T> list, IEnumerable<T> others)
        where T: XTypedElement
    {
        if (others == null) return list;

        list.AddRange(others);

        return list;
    }

    public static IList<T> Concatenate<T>(this IList<T> list, IEnumerable<T> others)
        where T : XTypedElement
    {
        if (others == null) return list;

        return list.Concat(others).ToList();
    }

    public static IList<T> DistinctMerge<T>(this IList<T> list, IEnumerable<T> others)
        where T: XTypedElement
    {
        return list.Merge(others).Distinct(XTypedElementDeepEqualityComparer<T>.Default).ToList();
    }
}