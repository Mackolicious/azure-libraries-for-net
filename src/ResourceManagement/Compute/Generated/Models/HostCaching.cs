// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for HostCaching.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HostCaching
    {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "ReadOnly")]
        ReadOnly,
        [EnumMember(Value = "ReadWrite")]
        ReadWrite
    }
    internal static class HostCachingEnumExtension
    {
        internal static string ToSerializedValue(this HostCaching? value)
        {
            return value == null ? null : ((HostCaching)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this HostCaching value)
        {
            switch( value )
            {
                case HostCaching.None:
                    return "None";
                case HostCaching.ReadOnly:
                    return "ReadOnly";
                case HostCaching.ReadWrite:
                    return "ReadWrite";
            }
            return null;
        }

        internal static HostCaching? ParseHostCaching(this string value)
        {
            switch( value )
            {
                case "None":
                    return HostCaching.None;
                case "ReadOnly":
                    return HostCaching.ReadOnly;
                case "ReadWrite":
                    return HostCaching.ReadWrite;
            }
            return null;
        }
    }
}