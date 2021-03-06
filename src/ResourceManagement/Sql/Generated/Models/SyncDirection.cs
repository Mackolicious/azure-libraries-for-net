// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Management.ResourceManager;
    using Management.ResourceManager.Fluent;
    using Management.ResourceManager.Fluent.Core;

    using Newtonsoft.Json;
    /// <summary>
    /// Defines values for SyncDirection.
    /// </summary>
    /// <summary>
    /// Determine base value for a given allowed value if exists, else return
    /// the value itself
    /// </summary>
    [JsonConverter(typeof(Management.ResourceManager.Fluent.Core.ExpandableStringEnumConverter<SyncDirection>))]
    public class SyncDirection : Management.ResourceManager.Fluent.Core.ExpandableStringEnum<SyncDirection>
    {
        public static readonly SyncDirection Bidirectional = Parse("Bidirectional");
        public static readonly SyncDirection OneWayMemberToHub = Parse("OneWayMemberToHub");
        public static readonly SyncDirection OneWayHubToMember = Parse("OneWayHubToMember");
    }
}
