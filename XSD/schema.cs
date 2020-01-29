using System.Linq;

namespace W3C.XSD
{
    public partial class schema
    {
        /// <summary>
        /// Returns a new instance of a <see cref="schema"/> which includes all the schema contents references in any <see cref="include"/>
        /// directives in the current schema.
        /// <para>When there are no <see cref="include"/> directives, returns the current schema.</para>
        /// </summary>
        /// <returns></returns>
        public schema ResolveIncludes()
        {
            if (!include.Any()) return this;

            var resolvedSchema = (schema)Clone();

            foreach (var inc in include) {
                var filePath = inc.schemaLocation.IsAbsoluteUri
                    ? inc.schemaLocation.AbsolutePath
                    : inc.schemaLocation.OriginalString;
                var includedSchema = schema.Load(filePath);
                resolvedSchema = resolvedSchema.Cascade(includedSchema);
            }

            return resolvedSchema;
        }

        /// <summary>
        /// Cascade the contents of <paramref cref="another"/> schema with the current one.
        /// </summary>
        /// <param name="another"></param>
        /// <returns>Returns a new instance of a <see cref="schema"/></returns>
        public schema Cascade(schema another)
        {
            var anotherWithResolvedIncludes = another.ResolveIncludes();

            var cascadedSchema = new schema {
                redefine = redefine.Merge(anotherWithResolvedIncludes.redefineField),
                annotation = annotation.Merge(anotherWithResolvedIncludes.annotation),
                attribute = attribute.Merge(anotherWithResolvedIncludes.attribute),
                attributeGroup = attributeGroup.Merge(anotherWithResolvedIncludes.attributeGroup),
                attributeFormDefault = anotherWithResolvedIncludes.attributeFormDefault,
                complexType = complexType.Merge(anotherWithResolvedIncludes.complexType),
                element = element.Merge(anotherWithResolvedIncludes.element),
                elementFormDefault = elementFormDefault ?? anotherWithResolvedIncludes.elementFormDefault,
                group = group.Merge(anotherWithResolvedIncludes.group),
                import = import.Merge(anotherWithResolvedIncludes.import),
                id = id ?? anotherWithResolvedIncludes.id,
                notation = notation.Merge(anotherWithResolvedIncludes.notation),
                simpleType = simpleType.Merge(anotherWithResolvedIncludes.simpleType),
                targetNamespace = targetNamespace ?? anotherWithResolvedIncludes.targetNamespace,
                version = version ?? anotherWithResolvedIncludes.version
            };

            var possibleBlockDefaultValue = blockDefault ?? anotherWithResolvedIncludes.blockDefault;
            if (possibleBlockDefaultValue != null) cascadedSchema.blockDefault = possibleBlockDefaultValue;

            var possibleFinalDefaultValue = finalDefault ?? anotherWithResolvedIncludes.finalDefault;
            if (possibleFinalDefaultValue != null) cascadedSchema.finalDefault = possibleFinalDefaultValue;

            //var possibleLangValue = lang ?? anotherWithResolvedIncludes.lang;
            //if (possibleLangValue != null && possibleLangValue != lang) cascadedSchema.lang = lang ?? anotherWithResolvedIncludes.lang;

            return cascadedSchema;
        }
    }
}