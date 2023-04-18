using System.Xml;

namespace W3C.XSD;

public class XQualifedName: XmlQualifiedName
{
    private readonly string _nsPrefix;

    public string NamespacePrefix
    {
        get => _nsPrefix;
    }

    public override string ToString()
    {
        if (_nsPrefix == null) {
            return base.ToString();
        }

        return NamespacePrefix.Length == 0 ? Name : string.Concat(NamespacePrefix, ":", Name);
    }

    public XQualifedName(string name, string ns, string nsPrefix) : base(name, ns)
    {
        _nsPrefix = nsPrefix;
    }
}