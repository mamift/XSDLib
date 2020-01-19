# XSDLib

A small, compact library for reading and writing XSD files.

![Nuget](https://buildstats.info/nuget/XSDLib)

## Example code

The following creates a small schema, with one element that has one attribute:

```C#
var schema = new schema();
var globalAttr = new attribute(new topLevelAttribute() {
  name = "name"
});

var globalEl = new element(new topLevelElement() {
  name = "anElement",
  complexType = new localComplexType() {
    attribute = { 
      new attributeType() { 
        @ref = new XmlQualifiedName("name") 
      } 
    }
  }
});

schema.attribute.Add(globalAttr);
schema.element.Add(globalEl);
```

## About

This library is made possible by the fact that W3C XSD has a schema for its own specification. As in, there's an XSD for XSD. Of course not everything is self-describable, such as key constraints, but this library allows reading, updating existing and creating new XSD files.