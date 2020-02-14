using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Xml.Schema.Linq.Extensions;

namespace W3C.XSD.Tests
{
    public class patternTests: SetupBase
    {
        [Test]
        public void PatternsHaveValuesTest()
        {
            var simpleTypesWithPatterns = XsdXsd.simpleType.Where(s => s.Content.restriction?.pattern?.Any() ?? false).ToList();
            Assert.IsNotEmpty(simpleTypesWithPatterns);
            Assert.IsTrue(simpleTypesWithPatterns.Count == 5);

            var thosePatterns = simpleTypesWithPatterns.SelectMany(s => s.Content.restriction?.pattern ?? new List<pattern>()).ToList();
            Assert.IsNotEmpty(thosePatterns);
            Assert.IsTrue(thosePatterns.Count == 5);

            // are noFixedFacet types
            Assert.IsTrue(thosePatterns.All(p => p is noFixedFacet pFacet));

            var result = thosePatterns.All(p => p.value.IsNotEmpty());
            Assert.IsTrue(result);
        }
    }
}