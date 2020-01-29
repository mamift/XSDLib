using NUnit.Framework;

namespace W3C.XSD.Tests
{
    public class schemaTests: SetupBase
    {
        [Test]
        public void TestCascadeElements()
        {
            var cascaded = XmlXsd.Cascade(new schema() {
                element = {
                    new element(new topLevelElement() { name = "testingElementThatShouldNotBeIn" })
                }
            });

            Assert.IsTrue(XmlXsd.element.Count == 0);
            Assert.IsTrue(cascaded.element.Count == 1);
        }

        [Test]
        public void TestCascadeAttributes()
        {
            var cascaded = XmlXsd.Cascade(new schema() {
                attribute = {
                    new attribute(new topLevelAttribute() { name = "testingAttr" })
                }
            });

            Assert.IsTrue(XmlXsd.attribute.Count == 4);
            Assert.IsTrue(cascaded.attribute.Count == 5);
        }

        [Test]
        public void TestResolveIncludesWithZeroIncludes()
        {
            var resolved = XmlXsd.ResolveIncludes();

            Assert.AreEqual(resolved, XmlXsd);
        }
    }
}