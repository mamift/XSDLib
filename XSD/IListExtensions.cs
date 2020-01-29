using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xml.Schema.Linq;

namespace W3C.XSD
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class IListExtensions
    {
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

            var concatenated = list.Concat(others);

            return concatenated.ToList();
        }

        public static IList<T> DistinctMerge<T>(this IList<T> list, IEnumerable<T> others)
            where T: XTypedElement
        {
            return list.Merge(others).Distinct(XTypedElementIEqualityComparer<T>.Default).ToList();
        }
    }
}