using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml.Linq;
using Xml.Schema.Linq;

namespace W3C.XSD;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public interface schemaInterface
{
    /// <summary>
    /// <para>
    /// Occurrence: required, choice
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: ((include | import | redefine | annotation)*, ((simpleType | complexType | group | attributeGroup | element | attribute | notation), annotation*)*)
    /// </para>
    /// </summary>
    IList<include> include { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: required, choice
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: ((include | import | redefine | annotation)*, ((simpleType | complexType | group | attributeGroup | element | attribute | notation), annotation*)*)
    /// </para>
    /// </summary>
    IList<import> import { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: required, choice
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: ((include | import | redefine | annotation)*, ((simpleType | complexType | group | attributeGroup | element | attribute | notation), annotation*)*)
    /// </para>
    /// </summary>
    IList<redefine> redefine { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: required, choice
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: ((include | import | redefine | annotation)*, ((simpleType | complexType | group | attributeGroup | element | attribute | notation), annotation*)*)
    /// </para>
    /// </summary>
    IList<annotation> annotation { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: required, choice
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: ((include | import | redefine | annotation)*, ((simpleType | complexType | group | attributeGroup | element | attribute | notation), annotation*)*)
    /// </para>
    /// </summary>
    IList<simpleType> simpleType { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: required, choice
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: ((include | import | redefine | annotation)*, ((simpleType | complexType | group | attributeGroup | element | attribute | notation), annotation*)*)
    /// </para>
    /// </summary>
    IList<complexType> complexType { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: required, choice
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: ((include | import | redefine | annotation)*, ((simpleType | complexType | group | attributeGroup | element | attribute | notation), annotation*)*)
    /// </para>
    /// </summary>
    IList<group> group { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: required, choice
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: ((include | import | redefine | annotation)*, ((simpleType | complexType | group | attributeGroup | element | attribute | notation), annotation*)*)
    /// </para>
    /// </summary>
    IList<attributeGroup> attributeGroup { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: required, choice
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: ((include | import | redefine | annotation)*, ((simpleType | complexType | group | attributeGroup | element | attribute | notation), annotation*)*)
    /// </para>
    /// </summary>
    IList<element> element { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: required, choice
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: ((include | import | redefine | annotation)*, ((simpleType | complexType | group | attributeGroup | element | attribute | notation), annotation*)*)
    /// </para>
    /// </summary>
    IList<attribute> attribute { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: required, choice
    /// </para>
    /// <para>
    /// Setter: Appends
    /// </para>
    /// <para>
    /// Regular expression: ((include | import | redefine | annotation)*, ((simpleType | complexType | group | attributeGroup | element | attribute | notation), annotation*)*)
    /// </para>
    /// </summary>
    IList<notation> notation { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: optional
    /// </para>
    /// </summary>
    System.Uri targetNamespace { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: optional
    /// </para>
    /// </summary>
    string version { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: optional
    /// </para>
    /// </summary>
    object finalDefault { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: optional
    /// </para>
    /// </summary>
    object blockDefault { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: optional
    /// </para>
    /// </summary>
    string attributeFormDefault { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: optional
    /// </para>
    /// </summary>
    string elementFormDefault { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: optional
    /// </para>
    /// </summary>
    string id { get; set; }

    /// <summary>
    /// <para>
    /// Occurrence: optional
    /// </para>
    /// </summary>
    object lang { get; set; }

    /// <summary>
    /// Preserves the original <see cref="FileInfo"/> object that may have been given using the <see cref="Load(System.IO.FileInfo)"/> method.
    /// </summary>
    FileInfo FileInfo { get; }

    XElement Untyped { get; set; }
    IXTyped Query { get; }

    void Save(string xmlFile);
    void Save(System.IO.TextWriter tw);
    void Save(System.Xml.XmlWriter xmlWriter);
    XTypedElement Clone();
    string ToString();
}