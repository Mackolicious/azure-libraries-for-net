// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Batch.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Contains information about an application in a Batch account.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class ApplicationInner : Management.ResourceManager.Fluent.Resource
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationInner class.
        /// </summary>
        public ApplicationInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationInner class.
        /// </summary>
        /// <param name="displayName">The display name for the
        /// application.</param>
        /// <param name="allowUpdates">A value indicating whether packages
        /// within the application may be overwritten using the same version
        /// string.</param>
        /// <param name="defaultVersion">The package to use if a client
        /// requests the application but does not specify a version. This
        /// property can only be set to the name of an existing
        /// package.</param>
        /// <param name="etag">The ETag of the resource, used for concurrency
        /// statements.</param>
        public ApplicationInner(string id = default(string), string name = default(string), string type = default(string), string displayName = default(string), bool? allowUpdates = default(bool?), string defaultVersion = default(string), string etag = default(string))
            : base(id, name, type)
        {
            DisplayName = displayName;
            AllowUpdates = allowUpdates;
            DefaultVersion = defaultVersion;
            Etag = etag;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the display name for the application.
        /// </summary>
        [JsonProperty(PropertyName = "properties.displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether packages within the
        /// application may be overwritten using the same version string.
        /// </summary>
        [JsonProperty(PropertyName = "properties.allowUpdates")]
        public bool? AllowUpdates { get; set; }

        /// <summary>
        /// Gets or sets the package to use if a client requests the
        /// application but does not specify a version. This property can only
        /// be set to the name of an existing package.
        /// </summary>
        [JsonProperty(PropertyName = "properties.defaultVersion")]
        public string DefaultVersion { get; set; }

        /// <summary>
        /// Gets the ETag of the resource, used for concurrency statements.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; private set; }

    }
}