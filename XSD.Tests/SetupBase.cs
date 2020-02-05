using System;
using System.IO;
using NUnit.Framework;

namespace W3C.XSD.Tests
{
    public abstract class SetupBase
    {
        public schema XsdXsd { get; set; }
        public schema XmlXsd { get; set; }

        public schema localTestXsd { get; set; }
        public schema localIncludedXsd { get; set; }

        [SetUp]
        public void Setup()
        {
            XmlXsd = schema.Load(@"xml.xsd");
            var xmlXsdv1a = new FileInfo(@"xsdschema (ms-visualstudio version).xsd");
            var xmlXsdv1b = new FileInfo(@"XMLSchema_v1.xsd");
            XsdXsd = schema.Load(xmlXsdv1b);
            localTestXsd = schema.Load(@"localTest.xsd");
            localIncludedXsd = schema.Load(@"localIncluded.xsd");
        }
    }
}