﻿// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Google.Api.Generator.Utils;
using Google.Api.Generator.Utils.Roslyn;
using Google.Apis.Discovery.v1.Data;
using Google.Apis.Requests;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;

namespace Google.Api.Generator.Rest.Models
{
    public class DataModel
    {
        private readonly JsonSchema _schema;

        public PackageModel Package { get; }

        /// <summary>
        /// The ID for the model, used in "$ref" properties.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The parent of this data model, if any.
        /// </summary>
        public DataModel Parent { get; }
        public string Name { get; }
        public Typ Typ { get; }
        public IReadOnlyList<DataModel> Children { get; }
        public IReadOnlyList<DataPropertyModel> Properties { get; }

        public DataModel(PackageModel package, DataModel parent, string name, JsonSchema schema)
        {
            Id = schema.Id;
            Package = package;
            Parent = parent;
            Name = name;
            Typ = parent is null ? Typ.Manual(Package.PackageName + ".Data", Name) : Typ.Nested(parent.Typ, Name);

            // We may get a JsonSchema for an array as a nested model. Just use the properties from schema.Items for simplicity.
            Properties = (schema.Properties ?? schema.Items.Properties).ToReadOnlyList(pair => new DataPropertyModel(this, pair.Key, pair.Value));
            _schema = schema;
        }

        public ClassDeclarationSyntax GenerateClass(SourceFileContext ctx)
        {
            var cls = Class(Modifier.Public, Typ, Parent is null ? new[] { ctx.Type<IDirectResponseSchema>() } : Array.Empty<TypeSyntax>());
            using (ctx.InClass(Typ))
            {
                if (_schema.Description is string description)
                {
                    cls = cls.WithXmlDoc(XmlDoc.Summary(description));
                }
                cls = cls.AddMembers(Properties.SelectMany(p => p.GeneratePropertyDeclarations(ctx)).ToArray());
                cls = cls.AddMembers(Properties.SelectMany(p => p.GenerateAnonymousModels(ctx)).ToArray());

                // Top-level data models automatically have an etag property if one isn't otherwise generated.
                if (Parent is null && !Properties.Any(p => p.Name == "etag"))
                {
                    var etag = AutoProperty(Modifier.Public | Modifier.Virtual, ctx.Type<string>(), "ETag", hasSetter: true)
                        .WithXmlDoc(XmlDoc.Summary("The ETag of the item."));
                    cls = cls.AddMembers(etag);
                }
            }
            return cls;
        }

    }
}
