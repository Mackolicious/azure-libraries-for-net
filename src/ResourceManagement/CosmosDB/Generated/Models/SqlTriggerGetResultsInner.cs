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
    /// An Azure Cosmos DB trigger.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class SqlTriggerGetResultsInner : ARMResourcePropertiesInner
    {
        /// <summary>
        /// Initializes a new instance of the SqlTriggerGetResultsInner class.
        /// </summary>
        public SqlTriggerGetResultsInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SqlTriggerGetResultsInner class.
        /// </summary>
        /// <param name="sqlTriggerGetResultsId">Name of the Cosmos DB SQL
        /// trigger</param>
        /// <param name="body">Body of the Trigger</param>
        /// <param name="triggerType">Type of the Trigger. Possible values
        /// include: 'Pre', 'Post'</param>
        /// <param name="triggerOperation">The operation the trigger is
        /// associated with. Possible values include: 'All', 'Create',
        /// 'Update', 'Delete', 'Replace'</param>
        /// <param name="_rid">A system generated property. A unique
        /// identifier.</param>
        /// <param name="_ts">A system generated property that denotes the last
        /// updated timestamp of the resource.</param>
        /// <param name="_etag">A system generated property representing the
        /// resource etag required for optimistic concurrency control.</param>
        public SqlTriggerGetResultsInner(string location, string sqlTriggerGetResultsId, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string body = default(string), TriggerType triggerType = default(TriggerType), TriggerOperation triggerOperation = default(TriggerOperation), string _rid = default(string), object _ts = default(object), string _etag = default(string))
            : base(location, id, name, type, tags)
        {
            SqlTriggerGetResultsId = sqlTriggerGetResultsId;
            Body = body;
            TriggerType = triggerType;
            TriggerOperation = triggerOperation;
            this._rid = _rid;
            this._ts = _ts;
            this._etag = _etag;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets name of the Cosmos DB SQL trigger
        /// </summary>
        [JsonProperty(PropertyName = "properties.id")]
        public string SqlTriggerGetResultsId { get; set; }

        /// <summary>
        /// Gets or sets body of the Trigger
        /// </summary>
        [JsonProperty(PropertyName = "properties.body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets type of the Trigger. Possible values include: 'Pre',
        /// 'Post'
        /// </summary>
        [JsonProperty(PropertyName = "properties.triggerType")]
        public TriggerType TriggerType { get; set; }

        /// <summary>
        /// Gets or sets the operation the trigger is associated with. Possible
        /// values include: 'All', 'Create', 'Update', 'Delete', 'Replace'
        /// </summary>
        [JsonProperty(PropertyName = "properties.triggerOperation")]
        public TriggerOperation TriggerOperation { get; set; }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        [JsonProperty(PropertyName = "properties._rid")]
        public string _rid { get; private set; }

        /// <summary>
        /// Gets a system generated property that denotes the last updated
        /// timestamp of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties._ts")]
        public object _ts { get; private set; }

        /// <summary>
        /// Gets a system generated property representing the resource etag
        /// required for optimistic concurrency control.
        /// </summary>
        [JsonProperty(PropertyName = "properties._etag")]
        public string _etag { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
            if (SqlTriggerGetResultsId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "SqlTriggerGetResultsId");
            }
        }
    }
}
