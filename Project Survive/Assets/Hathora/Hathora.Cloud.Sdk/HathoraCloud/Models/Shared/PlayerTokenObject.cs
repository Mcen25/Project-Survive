
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
    
    [Serializable]
    public class PlayerTokenObject
    {

        /// <summary>
        /// A unique Hathora-signed JWT player token.
        /// </summary>
        [SerializeField]
        [JsonProperty("token")]
        public string Token { get; set; } = default!;
    }
}