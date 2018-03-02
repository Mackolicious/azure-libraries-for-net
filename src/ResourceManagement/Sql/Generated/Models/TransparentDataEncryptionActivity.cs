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
    /// Represents a database transparent data encryption Scan.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class TransparentDataEncryptionActivity : ProxyResourceInner
    {
        /// <summary>
        /// Initializes a new instance of the TransparentDataEncryptionActivity
        /// class.
        /// </summary>
        public TransparentDataEncryptionActivity()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TransparentDataEncryptionActivity
        /// class.
        /// </summary>
        /// <param name="status">The status of the database. Possible values
        /// include: 'Encrypting', 'Decrypting'</param>
        /// <param name="percentComplete">The percent complete of the
        /// transparent data encryption scan for a database.</param>
        public TransparentDataEncryptionActivity(string id = default(string), string name = default(string), string type = default(string), string status = default(string), double? percentComplete = default(double?))
            : base(id, name, type)
        {
            Status = status;
            PercentComplete = percentComplete;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the status of the database. Possible values include:
        /// 'Encrypting', 'Decrypting'
        /// </summary>
        [JsonProperty(PropertyName = "properties.status")]
        public string Status { get; private set; }

        /// <summary>
        /// Gets the percent complete of the transparent data encryption scan
        /// for a database.
        /// </summary>
        [JsonProperty(PropertyName = "properties.percentComplete")]
        public double? PercentComplete { get; private set; }

    }
}
