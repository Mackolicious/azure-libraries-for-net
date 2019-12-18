// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Properties of the application rule protocol.
    /// </summary>
    public partial class AzureFirewallApplicationRuleProtocol
    {
        /// <summary>
        /// Initializes a new instance of the
        /// AzureFirewallApplicationRuleProtocol class.
        /// </summary>
        public AzureFirewallApplicationRuleProtocol()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// AzureFirewallApplicationRuleProtocol class.
        /// </summary>
        /// <param name="protocolType">Protocol type. Possible values include:
        /// 'Http', 'Https', 'Mssql'</param>
        /// <param name="port">Port number for the protocol, cannot be greater
        /// than 64000. This field is optional.</param>
        public AzureFirewallApplicationRuleProtocol(AzureFirewallApplicationRuleProtocolType protocolType = default(AzureFirewallApplicationRuleProtocolType), int? port = default(int?))
        {
            ProtocolType = protocolType;
            Port = port;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets protocol type. Possible values include: 'Http',
        /// 'Https', 'Mssql'
        /// </summary>
        [JsonProperty(PropertyName = "protocolType")]
        public AzureFirewallApplicationRuleProtocolType ProtocolType { get; set; }

        /// <summary>
        /// Gets or sets port number for the protocol, cannot be greater than
        /// 64000. This field is optional.
        /// </summary>
        [JsonProperty(PropertyName = "port")]
        public int? Port { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Port > 64000)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Port", 64000);
            }
            if (Port < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Port", 0);
            }
        }
    }
}
