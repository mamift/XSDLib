using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace W3C.XSD
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class simpleType
    {
        public bool IsRestriction => this.Content.restriction != null;

        public bool IsUnion
        {
            get {
                var hasUnionEl = this.Content.union != null;
                return hasUnionEl && this.Content.union.memberTypes.Any();
            }
        }
    }
}