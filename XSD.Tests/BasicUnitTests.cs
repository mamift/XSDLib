using System;
using System.Xml;
using NUnit.Framework;

namespace W3C.XSD.Tests
{
    public class BasicUnitTests: SetupBase
    {
        [Test]
        public void CreateSchemaTest()
        {
            var schema = new schema();
            var globalAttr = new attribute(new topLevelAttribute() {
                name = "name"
            });

            var globalEl = new element(new topLevelElement() {
                name = "anElement",
                complexType = new localComplexType() {
                    attribute = { new attributeType() { @ref = new XmlQualifiedName("name") } }
                }
            });

            schema.attribute.Add(globalAttr);
            schema.element.Add(globalEl);

            Assert.IsNotEmpty(schema.attribute);
            Assert.IsNotEmpty(schema.element);
        }

        [Test]
        public void XsdXsdAttributesTest()
        {
            Assert.IsNull(XsdXsd.finalDefault);
            Assert.IsNull(XsdXsd.id);
            Assert.IsTrue(XsdXsd.attributeFormDefault == "unqualified");
            Assert.IsTrue(XsdXsd.blockDefault.ToString() == "#all");
            Assert.IsTrue(XsdXsd.elementFormDefault == "qualified");
            Assert.IsTrue(XsdXsd.targetNamespace == new Uri("http://www.w3.org/2001/XMLSchema"));
            Assert.IsTrue(XsdXsd.version == "1.0");
            Assert.Throws<NullReferenceException>(() => Assert.IsNull(XsdXsd.lang));
        }

        [Test]
        public void XsdXsdCollectionCountTest()
        {
            Assert.IsTrue(XsdXsd.annotation.Count == 8);
            Assert.IsTrue(XsdXsd.attributeGroup.Count == 2);
            Assert.IsTrue(XsdXsd.attribute.Count == 0);
            Assert.IsTrue(XsdXsd.complexType.Count == 35);
            Assert.IsTrue(XsdXsd.element.Count == 41);
            Assert.IsTrue(XsdXsd.group.Count == 12);
            Assert.IsTrue(XsdXsd.import.Count == 1);
            Assert.IsTrue(XsdXsd.include.Count == 0);
            Assert.IsTrue(XsdXsd.notation.Count == 2);
            Assert.IsTrue(XsdXsd.redefine.Count == 0);
            Assert.IsTrue(XsdXsd.simpleType.Count == 55);

            Assert.Pass();
        }

        [Test]
        public void XmlXsdTest()
        {
            Assert.IsTrue(XmlXsd.attribute.Count == 4);
            Assert.IsTrue(XmlXsd.attributeGroup.Count == 1);
            Assert.IsTrue(XmlXsd.annotation.Count == 4);
        }
    }
}