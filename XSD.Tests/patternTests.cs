using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace W3C.XSD.Tests
{
    public class patternTests: SetupBase
    {
        [Test]
        public void PatternsHaveValuesTest()
        {
            var simpleTypesWithPatterns = XsdXsd.simpleType.Where(s => s.Content.restriction?.pattern?.Any() ?? false).ToList();

            var thosePatterns = simpleTypesWithPatterns.SelectMany(s => s.Content.restriction?.pattern ?? new List<pattern>()).ToList();

            Assert.IsNotEmpty(simpleTypesWithPatterns);
        }
    }
}