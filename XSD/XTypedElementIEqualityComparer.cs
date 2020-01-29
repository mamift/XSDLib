using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Xml.Schema.Linq;

namespace W3C.XSD
{
    public class XTypedElementIEqualityComparer<T> : IEqualityComparer<T>
        where T: XTypedElement
    {
        public bool Equals(T x, T y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));

            return XNode.DeepEquals(x.Untyped, y.Untyped);
        }

        public int GetHashCode(T obj)
        {
            return obj.Untyped.GetHashCode();
        }

        public static readonly XTypedElementIEqualityComparer<T> Default = new XTypedElementIEqualityComparer<T>();
    }
}