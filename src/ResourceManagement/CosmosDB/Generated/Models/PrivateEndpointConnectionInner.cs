// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.CosmosDB.Fluent.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// A private endpoint connection
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class PrivateEndpointConnectionInner : ProxyResourceInner
    {
        /// <summary>
        /// Initializes a new instance of the PrivateEndpointConnectionInner
        /// class.
        /// </summary>
        public PrivateEndpointConnectionInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PrivateEndpointConnectionInner
        /// class.
        /// </summary>
        /// <param name="privateEndpoint">Private endpoint which the connection
        /// belongs to.</param>
        /// <param name="privateLinkServiceConnectionState">Connection State of
        /// the Private Endpoint Connection.</param>
        public PrivateEndpointConnectionInner(string id = default(string), string name = default(string), string type = default(string), PrivateEndpointProperty privateEndpoint = default(PrivateEndpointProperty), PrivateLinkServiceConnectionStateProperty privateLinkServiceConnectionState = default(PrivateLinkServiceConnectionStateProperty))
            : base(id, name, type)
        {
            PrivateEndpoint = privateEndpoint;
            PrivateLinkServiceConnectionState = privateLinkServiceConnectionState;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets private endpoint which the connection belongs to.
        /// </summary>
        [JsonProperty(PropertyName = "properties.privateEndpoint")]
        public PrivateEndpointProperty PrivateEndpoint { get; set; }

        /// <summary>
        /// Gets or sets connection State of the Private Endpoint Connection.
        /// </summary>
        [JsonProperty(PropertyName = "properties.privateLinkServiceConnectionState")]
        public PrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get; set; }

    }
}
