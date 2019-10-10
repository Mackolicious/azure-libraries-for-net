// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Specifies the log search query.
    /// </summary>
    public partial class Source
    {
        /// <summary>
        /// Initializes a new instance of the Source class.
        /// </summary>
        public Source()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Source class.
        /// </summary>
        /// <param name="dataSourceId">The resource uri over which log search
        /// query is to be run.</param>
        /// <param name="query">Log search query. Required for action type -
        /// AlertingAction</param>
        /// <param name="authorizedResources">List of  Resource referred into
        /// query</param>
        /// <param name="queryType">Set value to 'ResultCount'. Possible values
        /// include: 'ResultCount'</param>
        public Source(string dataSourceId, string query = default(string), IList<string> authorizedResources = default(IList<string>), QueryType queryType = default(QueryType))
        {
            Query = query;
            AuthorizedResources = authorizedResources;
            DataSourceId = dataSourceId;
            QueryType = queryType;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets log search query. Required for action type -
        /// AlertingAction
        /// </summary>
        [JsonProperty(PropertyName = "query")]
        public string Query { get; set; }

        /// <summary>
        /// Gets or sets list of  Resource referred into query
        /// </summary>
        [JsonProperty(PropertyName = "authorizedResources")]
        public IList<string> AuthorizedResources { get; set; }

        /// <summary>
        /// Gets or sets the resource uri over which log search query is to be
        /// run.
        /// </summary>
        [JsonProperty(PropertyName = "dataSourceId")]
        public string DataSourceId { get; set; }

        /// <summary>
        /// Gets or sets set value to 'ResultCount'. Possible values include:
        /// 'ResultCount'
        /// </summary>
        [JsonProperty(PropertyName = "queryType")]
        public QueryType QueryType { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (DataSourceId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DataSourceId");
            }
        }
    }
}
