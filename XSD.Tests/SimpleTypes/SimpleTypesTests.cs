using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;
using W3C.XSD.Extensions;

namespace W3C.XSD.Tests.SimpleTypes
{
    public class SimpleTypesTests
    {
        [Test]
        public void TestSimpleTypeDerivationTypes()
        {
            var filePath = @"SimpleTypes\st1.xsd";
            var testSchema = schema.Load(filePath);
            var targetNs = testSchema.targetNamespace;
            var targetNsAttr = testSchema.Untyped.Attributes().FirstOrDefault(ns => ns.IsNamespaceDeclaration && ns.Value == targetNs.ToString());
            var targetNsPrefix = targetNsAttr.Name.LocalName;


            var restrictionSimpleTypes = testSchema.simpleType.Where(st => st.IsRestriction);
            var listSimpleTypes = testSchema.simpleType.Where(st => st.IsList);
            var unionSimpleTypes = testSchema.simpleType.Where(st => st.IsUnion);

            Assert.IsNotEmpty(restrictionSimpleTypes);
            Assert.IsNotEmpty(listSimpleTypes);
            Assert.IsNotEmpty(unionSimpleTypes);
        }
    }
}