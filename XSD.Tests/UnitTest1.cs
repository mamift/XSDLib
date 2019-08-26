using System;
using System.Linq;
using NUnit.Framework;
using W3C.XSD;

namespace XSD.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var xsdXsd = schema.Load(@"C:\Users\mmiftah\Projects\XSD\XSD\Schemas\XMLSchema_v1.xsd");
            var el = xsdXsd.element.First();
            
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            var xsdXsd = schema.Load(@"C:\Users\mmiftah\Projects\XSD\XSD\Schemas\XMLSchema_v1.xsd");
            var newSchema = new schema() {
                id = "",
                targetNamespace = new Uri("https://github.com/mamif")
            };

            Assert.IsNotNull(newSchema);
        }
    }
}