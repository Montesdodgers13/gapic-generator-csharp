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
using Google.Apis.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Rest.Models
{
    public class MethodModel
    {
        private RestMethod _restMethod;

        public PackageModel Package { get; }
        /// <summary>
        /// Resource that owns this method, if any.
        /// </summary>
        public ResourceModel Resource { get; }
        
        public IReadOnlyList<ParameterModel> Parameters { get; }
        public Typ ParentTyp { get; }
        public Typ RequestTyp { get; }
        public Typ ResponseTyp { get; }
        public Typ BodyTyp { get; }
        public string Name { get; }
        public string PascalCasedName { get; }

        public MethodModel(PackageModel package, ResourceModel resource, string name, RestMethod restMethod)
        {
            Package = package;
            Resource = resource;
            Name = name;
            PascalCasedName = name.ToUpperCamelCase();
            ParentTyp = resource?.Typ ?? package.ServiceTyp;
            RequestTyp = Typ.Nested(ParentTyp, $"{PascalCasedName}Request");
            BodyTyp = restMethod.Request is object ? package.GetDataModelByReference(restMethod.Request.Ref__).Typ : null;
            ResponseTyp = restMethod.Response is object ? package.GetDataModelByReference(restMethod.Response.Ref__).Typ : Typ.Of<string>();
            Parameters = CreateParameterList(package, restMethod, RequestTyp);
            _restMethod = restMethod;
        }

        private static IReadOnlyList<ParameterModel> CreateParameterList(PackageModel package, RestMethod restMethod, Typ parentTyp)
        {
            var parameterOrder = restMethod.ParameterOrder ?? new List<string>();
            // TODO: Skip the Alt parameter
            // TODO: Handle the body parameter if restMethod.Request is non-null
            return (restMethod.Parameters ?? new Dictionary<string, JsonSchema>())
                .Select(pair => new ParameterModel(package, pair.Key, pair.Value, parentTyp))
                .OrderBy(p => !p.IsRequired)
                .ThenBy(p => parameterOrder.IndexOf(p.Name))
                .ToList()
                .AsReadOnly();
        }

        public IEnumerable<MemberDeclarationSyntax> GenerateDeclarations(SourceFileContext ctx)
        {
            yield return GenerateMethodDeclaration(ctx);
            yield return GenerateRequestType(ctx);
        }

        private MethodDeclarationSyntax GenerateMethodDeclaration(SourceFileContext ctx)
        {
            var docs = new List<DocumentationCommentTriviaSyntax>();
            var methodParameters = Parameters.TakeWhile(p => p.IsRequired).ToList();
            var parameterDeclarations = methodParameters.Select(p => Parameter(ctx.Type(p.Typ), p.CodeParameterName)).ToList();
            if (_restMethod.Description is object)
            {
                docs.Add(XmlDoc.Summary(_restMethod.Description));
            }
            docs.AddRange(methodParameters.Zip(parameterDeclarations).Select(pair => XmlDoc.Param(pair.Second, pair.First.Description)));
            if (BodyTyp is object)
            {
                parameterDeclarations.Insert(0, Parameter(ctx.Type(BodyTyp), "body"));
                docs.Insert(1, XmlDoc.Param(parameterDeclarations[0], "The body of the request."));
            }

            var ctorArguments = new object[] { Field(0, ctx.Type<IClientService>(), "service") }
                .Concat(parameterDeclarations)
                .ToArray();
            var method = Method(Modifier.Public | Modifier.Virtual, ctx.Type(RequestTyp), PascalCasedName)(parameterDeclarations.ToArray())
                .WithBlockBody(Return(New(ctx.Type(RequestTyp))(ctorArguments)))
                .WithXmlDoc(docs.ToArray());
            return method;
        }

        private ClassDeclarationSyntax GenerateRequestType(SourceFileContext ctx)
        {
            var baseType = ctx.Type(Typ.Generic(Package.GenericBaseRequestTypDef, ResponseTyp));
            var cls = Class(Modifier.Public, RequestTyp, baseType);
            if (_restMethod.Description is object)
            {
                cls = cls.WithXmlDoc(XmlDoc.Summary(_restMethod.Description));
            }

            using (ctx.InClass(RequestTyp))
            {
                // Service and optionally "body"
                var serviceParam = Parameter(ctx.Type<IClientService>(), "service");
                ParameterSyntax bodyParam = null;
                var extraParameters = new List<ParameterSyntax> { serviceParam };

                var bodyDeclarations = new MemberDeclarationSyntax[0];
                if (BodyTyp is object)
                {
                    var bodyProperty = AutoProperty(Modifier.None, ctx.Type(BodyTyp), "Body", hasSetter: true)
                        .WithXmlDoc(XmlDoc.Summary("Gets or sets the body of this request."));
                    var bodyMethod = Method(Modifier.Protected | Modifier.Override, ctx.Type<object>(), "GetBody")()
                        .WithBody(Return(bodyProperty))
                        .WithXmlDoc(XmlDoc.Summary("Returns the body of the request."));
                    bodyDeclarations = new MemberDeclarationSyntax[] { bodyProperty, bodyMethod };
                    bodyParam = Parameter(ctx.Type(BodyTyp), "body");
                    extraParameters.Add(bodyParam);
                }

                var requiredParameters = Parameters
                    .TakeWhile(p => p.IsRequired)
                    .Select(p => (param: p, decl: Parameter(ctx.Type(p.Typ), p.CodeParameterName)))
                    .ToList();

                var assignments = requiredParameters
                    .Select(p => Field(0, ctx.Type(p.param.Typ), p.param.PropertyName).Assign(p.decl)).ToList();

                if (BodyTyp is object)
                {
                    var bodyProperty = (PropertyDeclarationSyntax) bodyDeclarations[0];
                    assignments.Add(bodyProperty.Assign(bodyParam));
                }

                // TODO: Add media download support

                var allCtorParameters = extraParameters.Concat(requiredParameters.Select(p => p.decl)).ToArray();

                var ctor = Ctor(Modifier.Public, cls, BaseInitializer(serviceParam))(allCtorParameters)
                    .WithXmlDoc(XmlDoc.Summary($"Constructs a new {PascalCasedName} request."))
                    .WithBlockBody(assignments.Concat<object>(new[] { InvocationExpression(IdentifierName("InitParameters")) }).ToArray());

                var methodName = Property(Modifier.Public | Modifier.Override, ctx.Type<string>(), "MethodName")
                    .WithGetBody(Name)
                    .WithXmlDoc(XmlDoc.Summary("Gets the method name."));

                var httpMethod = Property(Modifier.Public | Modifier.Override, ctx.Type<string>(), "HttpMethod")
                    .WithGetBody(_restMethod.HttpMethod)
                    .WithXmlDoc(XmlDoc.Summary("Gets the HTTP method."));

                var restPath = Property(Modifier.Public | Modifier.Override, ctx.Type<string>(), "RestPath")
                    .WithGetBody(_restMethod.Path)
                    .WithXmlDoc(XmlDoc.Summary("Gets the REST path."));

                var initParameters = Method(Modifier.Protected | Modifier.Override, VoidType, "InitParameters")()
                    .WithBlockBody(
                        BaseExpression().Call("InitParameters")(),
                        Parameters.Select(p => p.GenerateInitializer(ctx)).ToArray())
                    .WithXmlDoc(XmlDoc.Summary($"Initializes {PascalCasedName} parameter list."));

                // TODO: Media downloader members

                cls = cls.AddMembers(ctor);
                cls = cls.AddMembers(Parameters.SelectMany(p => p.GenerateDeclarations(ctx)).ToArray());
                cls = cls.AddMembers(bodyDeclarations);
                cls = cls.AddMembers(methodName, httpMethod, restPath, initParameters);
            }
            return cls;
        }
    }
}