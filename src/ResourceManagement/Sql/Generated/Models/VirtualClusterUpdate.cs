// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// An update request for an Azure SQL Database virtual cluster.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class VirtualClusterUpdate
    {
        /// <summary>
        /// Initializes a new instance of the VirtualClusterUpdate class.
        /// </summary>
        public VirtualClusterUpdate()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the VirtualClusterUpdate class.
        /// </summary>
        /// <param name="subnetId">Subnet resource ID for the virtual
        /// cluster.</param>
        /// <param name="family">If the service has different generations of
        /// hardware, for the same SKU, then that can be captured here.</param>
        /// <param name="childResources">List of resources in this virtual
        /// cluster.</param>
        /// <param name="tags">Resource tags.</param>
        public VirtualClusterUpdate(string subnetId = default(string), string family = default(string), IList<string> childResources = default(IList<string>), IDictionary<string, string> tags = default(IDictionary<string, string>))
        {
            SubnetId = subnetId;
            Family = family;
            ChildResources = childResources;
            Tags = tags;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets subnet resource ID for the virtual cluster.
        /// </summary>
        [JsonProperty(PropertyName = "properties.subnetId")]
        public string SubnetId { get; private set; }

        /// <summary>
        /// Gets or sets if the service has different generations of hardware,
        /// for the same SKU, then that can be captured here.
        /// </summary>
        [JsonProperty(PropertyName = "properties.family")]
        public string Family { get; set; }

        /// <summary>
        /// Gets list of resources in this virtual cluster.
        /// </summary>
        [JsonProperty(PropertyName = "properties.childResources")]
        public IList<string> ChildResources { get; private set; }

        /// <summary>
        /// Gets or sets resource tags.
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IDictionary<string, string> Tags { get; set; }

    }
}
