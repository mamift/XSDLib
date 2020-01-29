using NUnit.Framework;

namespace W3C.XSD.Tests
{
    public abstract class SetupBase
    {
        public schema XsdXsd { get; set; }
        public schema XmlXsd { get; set; }

        [SetUp]
        public void Setup()
        {
            XsdXsd = schema.Load(@"XMLSchema_v1.xsd");
            XmlXsd = schema.Load(@"xml.xsd");
        }
    }
}