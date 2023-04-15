using System.Diagnostics.CodeAnalysis;

namespace W3C.XSD
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class element
    {
        public localElement ToLocalElement()
        {
            localElement le = (localElement)this.Untyped;
            return le;
        }
    }
}