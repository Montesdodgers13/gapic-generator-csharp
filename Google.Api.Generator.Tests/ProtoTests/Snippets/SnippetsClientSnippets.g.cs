﻿namespace Testing.Snippets
{
    using Google.Api.Gax;
    using Google.Protobuf;
    using System.Threading.Tasks;

    /// <summary>Generated snippets.</summary>
    public sealed class GeneratedSnippetsSnippets
    {
        /// <summary>Snippet for MethodDefaultValues</summary>
        public void MethodDefaultValues_RequestObject()
        {
            // Snippet: MethodDefaultValues(DefaultValuesRequest, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            DefaultValuesRequest request = new DefaultValuesRequest
            {
                SingleDouble = 0,
                SingleFloat = 0F,
                SingleInt32 = 0,
                SingleInt64 = 0L,
                SingleUint32 = 0U,
                SingleUint64 = 0UL,
                SingleSint32 = 0,
                SingleSint64 = 0L,
                SingleFixed32 = 0U,
                SingleFixed64 = 0UL,
                SingleSfixed32 = 0,
                SingleSfixed64 = 0L,
                SingleBool = false,
                SingleString = "",
                SingleBytes = ByteString.Empty,
                SingleMessage = new AnotherMessage(),
                SingleNestedMessage = new DefaultValuesRequest.Types.NestedMessage(),
                SingleEnum = Enum.Default,
                SingleNestedEnum = DefaultValuesRequest.Types.NestedEnum.DefaultValue,
                RepeatedDouble = { 0, },
                RepeatedFloat = { 0F, },
                RepeatedInt32 = { 0, },
                RepeatedInt64 = { 0L, },
                RepeatedUint32 = { 0U, },
                RepeatedUint64 = { 0UL, },
                RepeatedSint32 = { 0, },
                RepeatedSint64 = { 0L, },
                RepeatedFixed32 = { 0U, },
                RepeatedFixed64 = { 0UL, },
                RepeatedSfixed32 = { 0, },
                RepeatedSfixed64 = { 0L, },
                RepeatedBool = { false, },
                RepeatedString = { "", },
                RepeatedBytes = { ByteString.Empty, },
                RepeatedMessage =
                {
                    new AnotherMessage(),
                },
                RepeatedNestedMessage =
                {
                    new DefaultValuesRequest.Types.NestedMessage(),
                },
                RepeatedEnum = { Enum.Default, },
                RepeatedNestedEnum =
                {
                    DefaultValuesRequest.Types.NestedEnum.DefaultValue,
                },
                SingleResourceNameAsAResourceName = new AResourceName("[ITEM_ID]", "[PART_ID]"),
                RepeatedResourceNameAsAResourceNames =
                {
                    new AResourceName("[ITEM_ID]", "[PART_ID]"),
                },
                SingleWildcardResourceAsResourceName = new UnknownResourceName("a/wildcard/resource"),
                RepeatedWildcardResourceAsResourceNames =
                {
                    new UnknownResourceName("a/wildcard/resource"),
                },
            };
            // Make the request
            Response response = snippetsClient.MethodDefaultValues(request);
            // End snippet
        }

        /// <summary>Snippet for MethodDefaultValuesAsync</summary>
        public async Task MethodDefaultValuesAsync_RequestObject()
        {
            // Snippet: MethodDefaultValuesAsync(DefaultValuesRequest, CallSettings)
            // Additional: MethodDefaultValuesAsync(DefaultValuesRequest, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            DefaultValuesRequest request = new DefaultValuesRequest
            {
                SingleDouble = 0,
                SingleFloat = 0F,
                SingleInt32 = 0,
                SingleInt64 = 0L,
                SingleUint32 = 0U,
                SingleUint64 = 0UL,
                SingleSint32 = 0,
                SingleSint64 = 0L,
                SingleFixed32 = 0U,
                SingleFixed64 = 0UL,
                SingleSfixed32 = 0,
                SingleSfixed64 = 0L,
                SingleBool = false,
                SingleString = "",
                SingleBytes = ByteString.Empty,
                SingleMessage = new AnotherMessage(),
                SingleNestedMessage = new DefaultValuesRequest.Types.NestedMessage(),
                SingleEnum = Enum.Default,
                SingleNestedEnum = DefaultValuesRequest.Types.NestedEnum.DefaultValue,
                RepeatedDouble = { 0, },
                RepeatedFloat = { 0F, },
                RepeatedInt32 = { 0, },
                RepeatedInt64 = { 0L, },
                RepeatedUint32 = { 0U, },
                RepeatedUint64 = { 0UL, },
                RepeatedSint32 = { 0, },
                RepeatedSint64 = { 0L, },
                RepeatedFixed32 = { 0U, },
                RepeatedFixed64 = { 0UL, },
                RepeatedSfixed32 = { 0, },
                RepeatedSfixed64 = { 0L, },
                RepeatedBool = { false, },
                RepeatedString = { "", },
                RepeatedBytes = { ByteString.Empty, },
                RepeatedMessage =
                {
                    new AnotherMessage(),
                },
                RepeatedNestedMessage =
                {
                    new DefaultValuesRequest.Types.NestedMessage(),
                },
                RepeatedEnum = { Enum.Default, },
                RepeatedNestedEnum =
                {
                    DefaultValuesRequest.Types.NestedEnum.DefaultValue,
                },
                SingleResourceNameAsAResourceName = new AResourceName("[ITEM_ID]", "[PART_ID]"),
                RepeatedResourceNameAsAResourceNames =
                {
                    new AResourceName("[ITEM_ID]", "[PART_ID]"),
                },
                SingleWildcardResourceAsResourceName = new UnknownResourceName("a/wildcard/resource"),
                RepeatedWildcardResourceAsResourceNames =
                {
                    new UnknownResourceName("a/wildcard/resource"),
                },
            };
            // Make the request
            Response response = await snippetsClient.MethodDefaultValuesAsync(request);
            // End snippet
        }

        /// <summary>Snippet for MethodOneSignature</summary>
        public void MethodOneSignature_RequestObject()
        {
            // Snippet: MethodOneSignature(SignatureRequest, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            SignatureRequest request = new SignatureRequest
            {
                AString = "",
                AnInt = 0,
                ABool = false,
            };
            // Make the request
            Response response = snippetsClient.MethodOneSignature(request);
            // End snippet
        }

        /// <summary>Snippet for MethodOneSignatureAsync</summary>
        public async Task MethodOneSignatureAsync_RequestObject()
        {
            // Snippet: MethodOneSignatureAsync(SignatureRequest, CallSettings)
            // Additional: MethodOneSignatureAsync(SignatureRequest, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            SignatureRequest request = new SignatureRequest
            {
                AString = "",
                AnInt = 0,
                ABool = false,
            };
            // Make the request
            Response response = await snippetsClient.MethodOneSignatureAsync(request);
            // End snippet
        }

        /// <summary>Snippet for MethodOneSignature</summary>
        public void MethodOneSignature()
        {
            // Snippet: MethodOneSignature(String, Int32, Boolean, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            string aString = "";
            int anInt = 0;
            bool aBool = false;
            // Make the request
            Response response = snippetsClient.MethodOneSignature(aString, anInt, aBool);
            // End snippet
        }

        /// <summary>Snippet for MethodOneSignatureAsync</summary>
        public async Task MethodOneSignatureAsync()
        {
            // Snippet: MethodOneSignatureAsync(String, Int32, Boolean, CallSettings)
            // Additional: MethodOneSignatureAsync(String, Int32, Boolean, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            string aString = "";
            int anInt = 0;
            bool aBool = false;
            // Make the request
            Response response = await snippetsClient.MethodOneSignatureAsync(aString, anInt, aBool);
            // End snippet
        }

        /// <summary>Snippet for MethodThreeSignatures</summary>
        public void MethodThreeSignatures_RequestObject()
        {
            // Snippet: MethodThreeSignatures(SignatureRequest, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            SignatureRequest request = new SignatureRequest
            {
                AString = "",
                AnInt = 0,
                ABool = false,
            };
            // Make the request
            Response response = snippetsClient.MethodThreeSignatures(request);
            // End snippet
        }

        /// <summary>Snippet for MethodThreeSignaturesAsync</summary>
        public async Task MethodThreeSignaturesAsync_RequestObject()
        {
            // Snippet: MethodThreeSignaturesAsync(SignatureRequest, CallSettings)
            // Additional: MethodThreeSignaturesAsync(SignatureRequest, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            SignatureRequest request = new SignatureRequest
            {
                AString = "",
                AnInt = 0,
                ABool = false,
            };
            // Make the request
            Response response = await snippetsClient.MethodThreeSignaturesAsync(request);
            // End snippet
        }

        /// <summary>Snippet for MethodThreeSignatures</summary>
        public void MethodThreeSignatures1()
        {
            // Snippet: MethodThreeSignatures(String, Int32, Boolean, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            string aString = "";
            int anInt = 0;
            bool aBool = false;
            // Make the request
            Response response = snippetsClient.MethodThreeSignatures(aString, anInt, aBool);
            // End snippet
        }

        /// <summary>Snippet for MethodThreeSignaturesAsync</summary>
        public async Task MethodThreeSignatures1Async()
        {
            // Snippet: MethodThreeSignaturesAsync(String, Int32, Boolean, CallSettings)
            // Additional: MethodThreeSignaturesAsync(String, Int32, Boolean, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            string aString = "";
            int anInt = 0;
            bool aBool = false;
            // Make the request
            Response response = await snippetsClient.MethodThreeSignaturesAsync(aString, anInt, aBool);
            // End snippet
        }

        /// <summary>Snippet for MethodThreeSignatures</summary>
        public void MethodThreeSignatures2()
        {
            // Snippet: MethodThreeSignatures(String, Boolean, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            string aString = "";
            bool aBool = false;
            // Make the request
            Response response = snippetsClient.MethodThreeSignatures(aString, aBool);
            // End snippet
        }

        /// <summary>Snippet for MethodThreeSignaturesAsync</summary>
        public async Task MethodThreeSignatures2Async()
        {
            // Snippet: MethodThreeSignaturesAsync(String, Boolean, CallSettings)
            // Additional: MethodThreeSignaturesAsync(String, Boolean, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            string aString = "";
            bool aBool = false;
            // Make the request
            Response response = await snippetsClient.MethodThreeSignaturesAsync(aString, aBool);
            // End snippet
        }

        /// <summary>Snippet for MethodThreeSignatures</summary>
        public void MethodThreeSignatures3()
        {
            // Snippet: MethodThreeSignatures(CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Make the request
            Response response = snippetsClient.MethodThreeSignatures();
            // End snippet
        }

        /// <summary>Snippet for MethodThreeSignaturesAsync</summary>
        public async Task MethodThreeSignatures3Async()
        {
            // Snippet: MethodThreeSignaturesAsync(CallSettings)
            // Additional: MethodThreeSignaturesAsync(CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Make the request
            Response response = await snippetsClient.MethodThreeSignaturesAsync();
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignature</summary>
        public void MethodResourceSignature_RequestObject()
        {
            // Snippet: MethodResourceSignature(ResourceSignatureRequest, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            ResourceSignatureRequest request = new ResourceSignatureRequest
            {
                FirstNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
                SecondNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
                ThirdNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
            };
            // Make the request
            Response response = snippetsClient.MethodResourceSignature(request);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignatureAsync</summary>
        public async Task MethodResourceSignatureAsync_RequestObject()
        {
            // Snippet: MethodResourceSignatureAsync(ResourceSignatureRequest, CallSettings)
            // Additional: MethodResourceSignatureAsync(ResourceSignatureRequest, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            ResourceSignatureRequest request = new ResourceSignatureRequest
            {
                FirstNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
                SecondNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
                ThirdNameAsSimpleResourceName = new SimpleResourceName("[ITEM_ID]"),
            };
            // Make the request
            Response response = await snippetsClient.MethodResourceSignatureAsync(request);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignature</summary>
        public void MethodResourceSignature1()
        {
            // Snippet: MethodResourceSignature(String, String, String, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            string firstName = "items/[ITEM_ID]";
            string secondName = "items/[ITEM_ID]";
            string thirdName = "items/[ITEM_ID]";
            // Make the request
            Response response = snippetsClient.MethodResourceSignature(firstName, secondName, thirdName);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignatureAsync</summary>
        public async Task MethodResourceSignature1Async()
        {
            // Snippet: MethodResourceSignatureAsync(String, String, String, CallSettings)
            // Additional: MethodResourceSignatureAsync(String, String, String, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            string firstName = "items/[ITEM_ID]";
            string secondName = "items/[ITEM_ID]";
            string thirdName = "items/[ITEM_ID]";
            // Make the request
            Response response = await snippetsClient.MethodResourceSignatureAsync(firstName, secondName, thirdName);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignature</summary>
        public void MethodResourceSignature1_ResourceNames()
        {
            // Snippet: MethodResourceSignature(SimpleResourceName, SimpleResourceName, SimpleResourceName, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            SimpleResourceName firstName = new SimpleResourceName("[ITEM_ID]");
            SimpleResourceName secondName = new SimpleResourceName("[ITEM_ID]");
            SimpleResourceName thirdName = new SimpleResourceName("[ITEM_ID]");
            // Make the request
            Response response = snippetsClient.MethodResourceSignature(firstName, secondName, thirdName);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignatureAsync</summary>
        public async Task MethodResourceSignature1Async_ResourceNames()
        {
            // Snippet: MethodResourceSignatureAsync(SimpleResourceName, SimpleResourceName, SimpleResourceName, CallSettings)
            // Additional: MethodResourceSignatureAsync(SimpleResourceName, SimpleResourceName, SimpleResourceName, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            SimpleResourceName firstName = new SimpleResourceName("[ITEM_ID]");
            SimpleResourceName secondName = new SimpleResourceName("[ITEM_ID]");
            SimpleResourceName thirdName = new SimpleResourceName("[ITEM_ID]");
            // Make the request
            Response response = await snippetsClient.MethodResourceSignatureAsync(firstName, secondName, thirdName);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignature</summary>
        public void MethodResourceSignature2()
        {
            // Snippet: MethodResourceSignature(String, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            string firstName = "items/[ITEM_ID]";
            // Make the request
            Response response = snippetsClient.MethodResourceSignature(firstName);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignatureAsync</summary>
        public async Task MethodResourceSignature2Async()
        {
            // Snippet: MethodResourceSignatureAsync(String, CallSettings)
            // Additional: MethodResourceSignatureAsync(String, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            string firstName = "items/[ITEM_ID]";
            // Make the request
            Response response = await snippetsClient.MethodResourceSignatureAsync(firstName);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignature</summary>
        public void MethodResourceSignature2_ResourceNames()
        {
            // Snippet: MethodResourceSignature(SimpleResourceName, CallSettings)
            // Create client
            SnippetsClient snippetsClient = SnippetsClient.Create();
            // Initialize request argument(s)
            SimpleResourceName firstName = new SimpleResourceName("[ITEM_ID]");
            // Make the request
            Response response = snippetsClient.MethodResourceSignature(firstName);
            // End snippet
        }

        /// <summary>Snippet for MethodResourceSignatureAsync</summary>
        public async Task MethodResourceSignature2Async_ResourceNames()
        {
            // Snippet: MethodResourceSignatureAsync(SimpleResourceName, CallSettings)
            // Additional: MethodResourceSignatureAsync(SimpleResourceName, CancellationToken)
            // Create client
            SnippetsClient snippetsClient = await SnippetsClient.CreateAsync();
            // Initialize request argument(s)
            SimpleResourceName firstName = new SimpleResourceName("[ITEM_ID]");
            // Make the request
            Response response = await snippetsClient.MethodResourceSignatureAsync(firstName);
            // End snippet
        }
    }
}