// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for BlobAuditingPolicyState.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BlobAuditingPolicyState
    {
        [EnumMember(Value = "Enabled")]
        Enabled,
        [EnumMember(Value = "Disabled")]
        Disabled
    }
    internal static class BlobAuditingPolicyStateEnumExtension
    {
        internal static string ToSerializedValue(this BlobAuditingPolicyState? value)
        {
            return value == null ? null : ((BlobAuditingPolicyState)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this BlobAuditingPolicyState value)
        {
            switch( value )
            {
                case BlobAuditingPolicyState.Enabled:
                    return "Enabled";
                case BlobAuditingPolicyState.Disabled:
                    return "Disabled";
            }
            return null;
        }

        internal static BlobAuditingPolicyState? ParseBlobAuditingPolicyState(this string value)
        {
            switch( value )
            {
                case "Enabled":
                    return BlobAuditingPolicyState.Enabled;
                case "Disabled":
                    return BlobAuditingPolicyState.Disabled;
            }
            return null;
        }
    }
}
