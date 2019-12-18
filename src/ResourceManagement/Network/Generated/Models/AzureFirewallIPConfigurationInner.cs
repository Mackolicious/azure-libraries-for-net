// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// IP configuration of an Azure Firewall.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class AzureFirewallIPConfigurationInner : Management.ResourceManager.Fluent.SubResource
    {
        /// <summary>
        /// Initializes a new instance of the AzureFirewallIPConfigurationInner
        /// class.
        /// </summary>
        public AzureFirewallIPConfigurationInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AzureFirewallIPConfigurationInner
        /// class.
        /// </summary>
        /// <param name="privateIPAddress">The Firewall Internal Load Balancer
        /// IP to be used as the next hop in User Defined Routes.</param>
        /// <param name="subnet">Reference of the subnet resource. This
        /// resource must be named 'AzureFirewallSubnet'.</param>
        /// <param name="publicIPAddress">Reference of the PublicIP resource.
        /// This field is a mandatory input if subnet is not null.</param>
        /// <param name="provisioningState">The provisioning state of the Azure
        /// firewall IP configuration resource. Possible values include:
        /// 'Succeeded', 'Updating', 'Deleting', 'Failed'</param>
        /// <param name="name">Name of the resource that is unique within a
        /// resource group. This name can be used to access the
        /// resource.</param>
        /// <param name="etag">A unique read-only string that changes whenever
        /// the resource is updated.</param>
        public AzureFirewallIPConfigurationInner(string id = default(string), string privateIPAddress = default(string), Management.ResourceManager.Fluent.SubResource subnet = default(Management.ResourceManager.Fluent.SubResource), Management.ResourceManager.Fluent.SubResource publicIPAddress = default(Management.ResourceManager.Fluent.SubResource), ProvisioningState provisioningState = default(ProvisioningState), string name = default(string), string etag = default(string))
            : base(id)
        {
            PrivateIPAddress = privateIPAddress;
            Subnet = subnet;
            PublicIPAddress = publicIPAddress;
            ProvisioningState = provisioningState;
            Name = name;
            Etag = etag;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the Firewall Internal Load Balancer IP to be used as the next
        /// hop in User Defined Routes.
        /// </summary>
        [JsonProperty(PropertyName = "properties.privateIPAddress")]
        public string PrivateIPAddress { get; private set; }

        /// <summary>
        /// Gets or sets reference of the subnet resource. This resource must
        /// be named 'AzureFirewallSubnet'.
        /// </summary>
        [JsonProperty(PropertyName = "properties.subnet")]
        public Management.ResourceManager.Fluent.SubResource Subnet { get; set; }

        /// <summary>
        /// Gets or sets reference of the PublicIP resource. This field is a
        /// mandatory input if subnet is not null.
        /// </summary>
        [JsonProperty(PropertyName = "properties.publicIPAddress")]
        public Management.ResourceManager.Fluent.SubResource PublicIPAddress { get; set; }

        /// <summary>
        /// Gets the provisioning state of the Azure firewall IP configuration
        /// resource. Possible values include: 'Succeeded', 'Updating',
        /// 'Deleting', 'Failed'
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public ProvisioningState ProvisioningState { get; private set; }

        /// <summary>
        /// Gets or sets name of the resource that is unique within a resource
        /// group. This name can be used to access the resource.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; private set; }

    }
}
