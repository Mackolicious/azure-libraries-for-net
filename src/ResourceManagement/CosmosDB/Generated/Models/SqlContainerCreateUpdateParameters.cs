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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Parameters to create and update Cosmos DB container.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class SqlContainerCreateUpdateParameters : ARMResourcePropertiesInner
    {
        /// <summary>
        /// Initializes a new instance of the
        /// SqlContainerCreateUpdateParameters class.
        /// </summary>
        public SqlContainerCreateUpdateParameters()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// SqlContainerCreateUpdateParameters class.
        /// </summary>
        /// <param name="resource">The standard JSON format of a
        /// container</param>
        /// <param name="options">A key-value pair of options to be applied for
        /// the request. This corresponds to the headers sent with the
        /// request.</param>
        public SqlContainerCreateUpdateParameters(string location, SqlContainerResource resource, IDictionary<string, string> options, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>))
            : base(location, id, name, type, tags)
        {
            Resource = resource;
            Options = options;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the standard JSON format of a container
        /// </summary>
        [JsonProperty(PropertyName = "properties.resource")]
        public SqlContainerResource Resource { get; set; }

        /// <summary>
        /// Gets or sets a key-value pair of options to be applied for the
        /// request. This corresponds to the headers sent with the request.
        /// </summary>
        [JsonProperty(PropertyName = "properties.options")]
        public IDictionary<string, string> Options { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
            if (Resource == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Resource");
            }
            if (Options == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Options");
            }
            if (Resource != null)
            {
                Resource.Validate();
            }
        }
    }
}
