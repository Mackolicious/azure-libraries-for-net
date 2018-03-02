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
    /// Represents a database replication link.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class ReplicationLinkInner : ProxyResourceInner
    {
        /// <summary>
        /// Initializes a new instance of the ReplicationLinkInner class.
        /// </summary>
        public ReplicationLinkInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ReplicationLinkInner class.
        /// </summary>
        /// <param name="location">Location of the server that contains this
        /// firewall rule.</param>
        /// <param name="isTerminationAllowed">Legacy value indicating whether
        /// termination is allowed.  Currently always returns true.</param>
        /// <param name="replicationMode">Replication mode of this replication
        /// link.</param>
        /// <param name="partnerServer">The name of the server hosting the
        /// partner database.</param>
        /// <param name="partnerDatabase">The name of the partner
        /// database.</param>
        /// <param name="partnerLocation">The Azure Region of the partner
        /// database.</param>
        /// <param name="role">The role of the database in the replication
        /// link. Possible values include: 'Primary', 'Secondary',
        /// 'NonReadableSecondary', 'Source', 'Copy'</param>
        /// <param name="partnerRole">The role of the partner database in the
        /// replication link. Possible values include: 'Primary', 'Secondary',
        /// 'NonReadableSecondary', 'Source', 'Copy'</param>
        /// <param name="startTime">The start time for the replication
        /// link.</param>
        /// <param name="percentComplete">The percentage of seeding complete
        /// for the replication link.</param>
        /// <param name="replicationState">The replication state for the
        /// replication link. Possible values include: 'PENDING', 'SEEDING',
        /// 'CATCH_UP', 'SUSPENDED'</param>
        public ReplicationLinkInner(string location = default(string), string id = default(string), string name = default(string), string type = default(string), bool? isTerminationAllowed = default(bool?), string replicationMode = default(string), string partnerServer = default(string), string partnerDatabase = default(string), string partnerLocation = default(string), ReplicationRole? role = default(ReplicationRole?), ReplicationRole? partnerRole = default(ReplicationRole?), System.DateTime? startTime = default(System.DateTime?), int? percentComplete = default(int?), string replicationState = default(string))
            : base(id, name, type)
        {
            Location = location;
            IsTerminationAllowed = isTerminationAllowed;
            ReplicationMode = replicationMode;
            PartnerServer = partnerServer;
            PartnerDatabase = partnerDatabase;
            PartnerLocation = partnerLocation;
            Role = role;
            PartnerRole = partnerRole;
            StartTime = startTime;
            PercentComplete = percentComplete;
            ReplicationState = replicationState;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets location of the server that contains this firewall rule.
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; private set; }

        /// <summary>
        /// Gets legacy value indicating whether termination is allowed.
        /// Currently always returns true.
        /// </summary>
        [JsonProperty(PropertyName = "properties.isTerminationAllowed")]
        public bool? IsTerminationAllowed { get; private set; }

        /// <summary>
        /// Gets replication mode of this replication link.
        /// </summary>
        [JsonProperty(PropertyName = "properties.replicationMode")]
        public string ReplicationMode { get; private set; }

        /// <summary>
        /// Gets the name of the server hosting the partner database.
        /// </summary>
        [JsonProperty(PropertyName = "properties.partnerServer")]
        public string PartnerServer { get; private set; }

        /// <summary>
        /// Gets the name of the partner database.
        /// </summary>
        [JsonProperty(PropertyName = "properties.partnerDatabase")]
        public string PartnerDatabase { get; private set; }

        /// <summary>
        /// Gets the Azure Region of the partner database.
        /// </summary>
        [JsonProperty(PropertyName = "properties.partnerLocation")]
        public string PartnerLocation { get; private set; }

        /// <summary>
        /// Gets the role of the database in the replication link. Possible
        /// values include: 'Primary', 'Secondary', 'NonReadableSecondary',
        /// 'Source', 'Copy'
        /// </summary>
        [JsonProperty(PropertyName = "properties.role")]
        public ReplicationRole? Role { get; private set; }

        /// <summary>
        /// Gets the role of the partner database in the replication link.
        /// Possible values include: 'Primary', 'Secondary',
        /// 'NonReadableSecondary', 'Source', 'Copy'
        /// </summary>
        [JsonProperty(PropertyName = "properties.partnerRole")]
        public ReplicationRole? PartnerRole { get; private set; }

        /// <summary>
        /// Gets the start time for the replication link.
        /// </summary>
        [JsonProperty(PropertyName = "properties.startTime")]
        public System.DateTime? StartTime { get; private set; }

        /// <summary>
        /// Gets the percentage of seeding complete for the replication link.
        /// </summary>
        [JsonProperty(PropertyName = "properties.percentComplete")]
        public int? PercentComplete { get; private set; }

        /// <summary>
        /// Gets the replication state for the replication link. Possible
        /// values include: 'PENDING', 'SEEDING', 'CATCH_UP', 'SUSPENDED'
        /// </summary>
        [JsonProperty(PropertyName = "properties.replicationState")]
        public string ReplicationState { get; private set; }

    }
}
