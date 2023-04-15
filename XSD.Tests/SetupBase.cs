using System;
using System.IO;
using NUnit.Framework;

namespace W3C.XSD.Tests
{
    public abstract class SetupBase
    {
        public schema XsdXsd { get; set; }
        public schema XsdXsdVsVersion { get; set; }
        public schema XmlXsd { get; set; }

        public schema localTestXsd { get; set; }
        public schema localIncludedXsd { get; set; }

        [SetUp]
        public void Setup()
        {
            XmlXsd = schema.Load(@"xml.xsd");
            XsdXsd = schema.Load(new FileInfo(@"XMLSchema_v1.xsd"));
            XsdXsdVsVersion = schema.Load(new FileInfo(@"xsdschema (ms-visualstudio version).xsd"));
            localTestXsd = schema.Load(@"localTest.xsd");
            localIncludedXsd = schema.Load(@"localIncluded.xsd");
        }
    }
}