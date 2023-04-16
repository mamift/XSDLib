using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace W3C.XSD
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class simpleType
    {
        public bool IsRestriction => Content.restriction != null;

        public bool IsList
        {
            get {
                var hasListEl = Content.list != null;
                return hasListEl && Content.list.itemType != null;
            }
        }

        public bool IsUnion
        {
            get {
                var hasUnionEl = Content.union != null;
                return hasUnionEl && Content.union.memberTypes.Any();
            }
        }
    }
}