using System.ComponentModel;
using System.Diagnostics;
using Xml.Schema.Linq;

namespace W3C.XSD
{
    /// <summary>
    /// <para>LinqToXsd generates this by default as an orphaned global element inheriting from <see cref="XTypedElement"/>.</para>
    /// </summary>
    public partial class pattern: noFixedFacet
    {
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private new bool @fixed { get; set; }
    }
}