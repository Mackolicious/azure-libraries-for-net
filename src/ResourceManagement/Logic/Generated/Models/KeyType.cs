// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Logic.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Fluent;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for KeyType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KeyType
    {
        [EnumMember(Value = "NotSpecified")]
        NotSpecified,
        [EnumMember(Value = "Primary")]
        Primary,
        [EnumMember(Value = "Secondary")]
        Secondary
    }
    internal static class KeyTypeEnumExtension
    {
        internal static string ToSerializedValue(this KeyType? value)
        {
            return value == null ? null : ((KeyType)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this KeyType value)
        {
            switch( value )
            {
                case KeyType.NotSpecified:
                    return "NotSpecified";
                case KeyType.Primary:
                    return "Primary";
                case KeyType.Secondary:
                    return "Secondary";
            }
            return null;
        }

        internal static KeyType? ParseKeyType(this string value)
        {
            switch( value )
            {
                case "NotSpecified":
                    return KeyType.NotSpecified;
                case "Primary":
                    return KeyType.Primary;
                case "Secondary":
                    return KeyType.Secondary;
            }
            return null;
        }
    }
}