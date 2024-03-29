﻿using System;
using System.Linq;
using NUnit.Framework;
using Xml.Schema.Linq.Extensions;

namespace W3C.XSD.Tests
{
    public class schemaTests : SetupBase
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
            Assert.IsTrue(XmlXsd.attribute.Count == 4);

            var cascaded = XmlXsd.Cascade(new schema() {
                attribute = {
                    new attribute(new topLevelAttribute() { name = "testingAttr" })
                }
            });

            // remains unchanged
            Assert.IsTrue(XmlXsd.attribute.Count == 4);
            Assert.IsTrue(cascaded.attribute.Count == 5);
        }

        [Test]
        public void TestResolveIncludesWithZeroIncludes()
        {
            var resolved = XmlXsd.ResolveIncludes();

            Assert.AreEqual(resolved, XmlXsd);
        }

        [Test]
        public void TestResolveIncludesWithRelativeUris()
        {
            Assert.DoesNotThrow(() => {
                var resolvedLocalTest = localTestXsd.ResolveIncludes();
                Assert.IsTrue(resolvedLocalTest.simpleType.Count == 2);
            });
        }

        [Test]
        public void TestIncludeUrisThatAreLocal()
        {
            Assert.IsTrue(localTestXsd.include.All(i => !i.schemaLocation.IsAbsoluteUri));
            Assert.IsTrue(localTestXsd.include.All(i => !i.schemaLocation.UserEscaped));
            Assert.IsTrue(localTestXsd.include.All(i => i.schemaLocation.OriginalString.IsNotEmpty()));

            Assert.Throws<InvalidOperationException>(() => {
                localTestXsd.include.Any(i => i.schemaLocation.IsDefaultPort);
            });
            Assert.Throws<InvalidOperationException>(() => {
                localTestXsd.include.Any(i => i.schemaLocation.IsFile);
            });
            Assert.Throws<InvalidOperationException>(() => {
                localTestXsd.include.Any(i => i.schemaLocation.IsLoopback);
            });
            Assert.Throws<InvalidOperationException>(() => {
                localTestXsd.include.Any(i => i.schemaLocation.IsUnc);
            });
        }
    }
}