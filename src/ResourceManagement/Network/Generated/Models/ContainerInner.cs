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
    using System.Linq;

    /// <summary>
    /// Reference to container resource in remote resource provider.
    /// </summary>
    public partial class ContainerInner : Management.ResourceManager.Fluent.SubResource
    {
        /// <summary>
        /// Initializes a new instance of the ContainerInner class.
        /// </summary>
        public ContainerInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ContainerInner class.
        /// </summary>
        public ContainerInner(string id = default(string))
            : base(id)
        {
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

    }
}
