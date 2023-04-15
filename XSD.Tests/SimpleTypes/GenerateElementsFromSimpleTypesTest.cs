using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;
using W3C.XSD.Extensions;

namespace W3C.XSD.Tests.SimpleTypes
{
    public class GenerateElementsFromSimpleTypesTest
    {
        [Test]
        public void GenerateElementsFromSimpleTypes()
        {
            var filePath = @"SimpleTypes\st1.xsd";
            var st1 = schema.Load(filePath);
            var targetNs = st1.targetNamespace;
            var targetNsAttr = st1.Untyped.Attributes().FirstOrDefault(ns => ns.IsNamespaceDeclaration && ns.Value == targetNs.ToString());
            var targetNsPrefix = targetNsAttr.Name.LocalName;

            foreach (var theSimpleType in st1.simpleType) {
                List<element> elementsFromEnumerations = new List<element>();

                if (theSimpleType.IsRestriction) {
                    var enumerations = theSimpleType.Content.restriction.enumeration.Select(e => e.Content.value)
                        .ToList();

                    elementsFromEnumerations.AddRange(enumerations.Select(e => {
                        var xmlQualifiedNameForSimpleType = new XmlQualifiedName(
                            $"{targetNsPrefix}:{theSimpleType.Content.name}", st1.targetNamespace.ToString());
                        return new element(new topLevelElement() {
                            name = $"{e}Keyword",
                            type = xmlQualifiedNameForSimpleType,
                            @fixed = e
                        });
                    }));

                    if (elementsFromEnumerations.Any()) {
                        var group = new group(new namedGroup() {
                            name = $"{theSimpleType.Content.name}Elements",
                        });
                        if (elementsFromEnumerations.Count == 1) {
                            var sequence = new sequence(new simpleExplicitGroup());
                            sequence.Content.element.Add(elementsFromEnumerations.First().ToLocalElement()
                                .WithDefaultMinAndMaxValues());
                            group.Content.sequence.Add(sequence);
                        }
                        else {
                            var choice = new choice(new simpleExplicitGroup());
                            choice.Content.element.AddRange(elementsFromEnumerations.Select(e =>
                                e.ToLocalElement().WithDefaultMinAndMaxValues()));
                            group.Content.choice.Add(choice);
                        }

                        st1.group.Add(group);
                    }
                } else if (theSimpleType.IsUnion) {

                }
            }

            st1.Save(filePath);
        }
    }
}