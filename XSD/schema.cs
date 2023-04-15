using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using W3C.XSD.Extensions;
using Xml.Schema.Linq;
using Xml.Schema.Linq.Extensions;

namespace W3C.XSD
{
    public partial class schema
    {
        /// <summary>
        /// Loads a new <see cref="schema"/> from an existing <see cref="System.IO.FileInfo"/>.
        /// <para>The given <see cref="System.IO.FileInfo"/> is saved in the <see cref="FileInfo"/> property.</para>
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public static schema Load(FileInfo fileInfo)
        {
            var schema = XTypedServices.Load<schema>(fileInfo.FullName);
            schema.FileInfo = fileInfo;

            return schema;
        }

        /// <summary>
        /// Preserves the original <see cref="FileInfo"/> object that may have been given using the <see cref="Load(System.IO.FileInfo)"/> method.
        /// </summary>
        public FileInfo FileInfo { get; private set; }

        /// <summary>
        /// Returns a new instance of a <see cref="schema"/> which includes all the schema contents references in any <see cref="include"/>
        /// directives in the current schema.
        /// <para>When there are no <see cref="include"/> directives, returns the current schema.</para>
        /// </summary>
        /// <param name="customDirectory">Search in a custom directory.</param>
        /// <returns></returns>
        public schema ResolveIncludes(string customDirectory = null)
        {
            if (!include.Any()) return this;

            if (customDirectory != null && !Directory.Exists(customDirectory))
                throw new DirectoryNotFoundException();

            var resolvedSchema = (schema) Clone();

            foreach (var includeDirective in include) {
                schema includedSchema = null;
                if (includeDirective.schemaLocation.IsAbsoluteUri) {
                    if (includeDirective.schemaLocation.IsFile) {
                        includedSchema = schema.Load(includeDirective.schemaLocation.AbsolutePath);
                    }
                    else {
                        var downloadedString = WebRequest.Create(includeDirective.schemaLocation).GetRequestStream()
                            .ReadAsString();
                        includedSchema = schema.Parse(downloadedString);
                    }
                }
                else {
                    var possibleFolder = FileInfo?.DirectoryName ?? customDirectory ?? Environment.CurrentDirectory;
                    // ReSharper disable once AssignNullToNotNullAttribute
                    var xmlFile = Path.Combine(possibleFolder, includeDirective.schemaLocation.OriginalString);
                    includedSchema = schema.Load(xmlFile);
                }

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
                redefine = redefine.Concatenate(anotherWithResolvedIncludes.redefineField),
                annotation = annotation.Concatenate(anotherWithResolvedIncludes.annotation),
                attribute = attribute.Concatenate(anotherWithResolvedIncludes.attribute),
                attributeGroup = attributeGroup.Concatenate(anotherWithResolvedIncludes.attributeGroup),
                attributeFormDefault = anotherWithResolvedIncludes.attributeFormDefault,
                complexType = complexType.Concatenate(anotherWithResolvedIncludes.complexType),
                element = element.Concatenate(anotherWithResolvedIncludes.element),
                elementFormDefault = elementFormDefault ?? anotherWithResolvedIncludes.elementFormDefault,
                group = group.Concatenate(anotherWithResolvedIncludes.group),
                import = import.Concatenate(anotherWithResolvedIncludes.import),
                id = id ?? anotherWithResolvedIncludes.id,
                notation = notation.Concatenate(anotherWithResolvedIncludes.notation),
                simpleType = simpleType.Concatenate(anotherWithResolvedIncludes.simpleType),
                targetNamespace = targetNamespace ?? anotherWithResolvedIncludes.targetNamespace,
                version = version ?? anotherWithResolvedIncludes.version,
                FileInfo = FileInfo
            };

            var possibleBlockDefaultValue = blockDefault ?? anotherWithResolvedIncludes.blockDefault;
            if (possibleBlockDefaultValue != null) cascadedSchema.blockDefault = possibleBlockDefaultValue;

            var possibleFinalDefaultValue = finalDefault ?? anotherWithResolvedIncludes.finalDefault;
            if (possibleFinalDefaultValue != null) cascadedSchema.finalDefault = possibleFinalDefaultValue;

            //var possibleLangValue = lang ?? anotherWithResolvedIncludes.lang;
            //if (possibleLangValue != null && possibleLangValue != lang) cascadedSchema.lang = lang ?? anotherWithResolvedIncludes.lang;

            return cascadedSchema;
        }

        public simpleType GetGlobalSimpleTypeForName(XmlQualifiedName name)
        {
            return simpleType.FirstOrDefault(t => t.Content.name == name.Name);
        }
    }
}