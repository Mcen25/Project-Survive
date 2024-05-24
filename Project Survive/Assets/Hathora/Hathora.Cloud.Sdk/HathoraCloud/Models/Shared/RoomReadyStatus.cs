
//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasyapi.dev). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace HathoraCloud.Models.Shared
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    public enum RoomReadyStatus
    {
        [JsonProperty("active")]
        Active,
        [JsonProperty("starting")]
        Starting,
    }

    public static class RoomReadyStatusExtension
    {
        public static string Value(this RoomReadyStatus value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static RoomReadyStatus ToEnum(this string value)
        {
            foreach(var field in typeof(RoomReadyStatus).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (RoomReadyStatus)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum RoomReadyStatus");
        }
    }

}