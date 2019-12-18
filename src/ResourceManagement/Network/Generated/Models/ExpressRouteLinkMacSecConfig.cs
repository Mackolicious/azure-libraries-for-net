// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Definition of ExpressRouteLink Mac Security configuration.
    /// </summary>
    /// <remarks>
    /// ExpressRouteLink Mac Security Configuration.
    /// </remarks>
    public partial class ExpressRouteLinkMacSecConfig
    {
        /// <summary>
        /// Initializes a new instance of the ExpressRouteLinkMacSecConfig
        /// class.
        /// </summary>
        public ExpressRouteLinkMacSecConfig()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ExpressRouteLinkMacSecConfig
        /// class.
        /// </summary>
        /// <param name="cknSecretIdentifier">Keyvault Secret Identifier URL
        /// containing Mac security CKN key.</param>
        /// <param name="cakSecretIdentifier">Keyvault Secret Identifier URL
        /// containing Mac security CAK key.</param>
        /// <param name="cipher">Mac security cipher. Possible values include:
        /// 'gcm-aes-128', 'gcm-aes-256'</param>
        public ExpressRouteLinkMacSecConfig(string cknSecretIdentifier = default(string), string cakSecretIdentifier = default(string), ExpressRouteLinkMacSecCipher cipher = default(ExpressRouteLinkMacSecCipher))
        {
            CknSecretIdentifier = cknSecretIdentifier;
            CakSecretIdentifier = cakSecretIdentifier;
            Cipher = cipher;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets keyvault Secret Identifier URL containing Mac security
        /// CKN key.
        /// </summary>
        [JsonProperty(PropertyName = "cknSecretIdentifier")]
        public string CknSecretIdentifier { get; set; }

        /// <summary>
        /// Gets or sets keyvault Secret Identifier URL containing Mac security
        /// CAK key.
        /// </summary>
        [JsonProperty(PropertyName = "cakSecretIdentifier")]
        public string CakSecretIdentifier { get; set; }

        /// <summary>
        /// Gets or sets mac security cipher. Possible values include:
        /// 'gcm-aes-128', 'gcm-aes-256'
        /// </summary>
        [JsonProperty(PropertyName = "cipher")]
        public ExpressRouteLinkMacSecCipher Cipher { get; set; }

    }
}
