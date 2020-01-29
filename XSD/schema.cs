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
                var includedSchema = schema.Load(inc.schemaLocation.LocalPath);
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

            var cascadedSchema = new schema();
            cascadedSchema.redefine = redefine.Merge(anotherWithResolvedIncludes.redefineField);
            cascadedSchema.annotation = annotation.Merge(anotherWithResolvedIncludes.annotation);
            cascadedSchema.attribute = attribute.Merge(anotherWithResolvedIncludes.attribute);
            cascadedSchema.attributeGroup = attributeGroup.Merge(anotherWithResolvedIncludes.attributeGroup);
            cascadedSchema.attributeFormDefault = anotherWithResolvedIncludes.attributeFormDefault;
            
            cascadedSchema.complexType = complexType.Merge(anotherWithResolvedIncludes.complexType);
            cascadedSchema.element = element.Merge(anotherWithResolvedIncludes.element);
            cascadedSchema.elementFormDefault = elementFormDefault ?? anotherWithResolvedIncludes.elementFormDefault;
            
            cascadedSchema.group = group.Merge(anotherWithResolvedIncludes.group);
            cascadedSchema.import = import.Merge(anotherWithResolvedIncludes.import);
            cascadedSchema.id = id ?? anotherWithResolvedIncludes.id;
            
            cascadedSchema.notation = notation.Merge(anotherWithResolvedIncludes.notation);
            cascadedSchema.simpleType = simpleType.Merge(anotherWithResolvedIncludes.simpleType);
            cascadedSchema.targetNamespace = targetNamespace ?? anotherWithResolvedIncludes.targetNamespace;
            cascadedSchema.version = version ?? anotherWithResolvedIncludes.version;

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