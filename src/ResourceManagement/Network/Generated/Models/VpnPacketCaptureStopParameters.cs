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
    /// Stop packet capture parameters.
    /// </summary>
    public partial class VpnPacketCaptureStopParameters
    {
        /// <summary>
        /// Initializes a new instance of the VpnPacketCaptureStopParameters
        /// class.
        /// </summary>
        public VpnPacketCaptureStopParameters()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the VpnPacketCaptureStopParameters
        /// class.
        /// </summary>
        /// <param name="sasUrl">SAS url for packet capture on virtual network
        /// gateway.</param>
        public VpnPacketCaptureStopParameters(string sasUrl = default(string))
        {
            SasUrl = sasUrl;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets SAS url for packet capture on virtual network gateway.
        /// </summary>
        [JsonProperty(PropertyName = "sasUrl")]
        public string SasUrl { get; set; }

    }
}
