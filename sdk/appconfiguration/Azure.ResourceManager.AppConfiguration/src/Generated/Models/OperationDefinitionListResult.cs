// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.AppConfiguration.Models
{
    /// <summary> The result of a request to list configuration store operations. </summary>
    internal partial class OperationDefinitionListResult
    {
        /// <summary> Initializes a new instance of OperationDefinitionListResult. </summary>
        internal OperationDefinitionListResult()
        {
            Value = new ChangeTrackingList<OperationDefinition>();
        }

        /// <summary> Initializes a new instance of OperationDefinitionListResult. </summary>
        /// <param name="value"> The collection value. </param>
        /// <param name="nextLink"> The URI that can be used to request the next set of paged results. </param>
        internal OperationDefinitionListResult(IReadOnlyList<OperationDefinition> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The collection value. </summary>
        public IReadOnlyList<OperationDefinition> Value { get; }
        /// <summary> The URI that can be used to request the next set of paged results. </summary>
        public string NextLink { get; }
    }
}
