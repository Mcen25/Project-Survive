
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
    using HathoraCloud.Models.Shared;
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class CreatedOrgToken
    {

        [SerializeField]
        [JsonProperty("orgToken")]
        public OrgToken OrgToken { get; set; } = default!;

        [SerializeField]
        [JsonProperty("plainTextToken")]
        public string PlainTextToken { get; set; } = default!;
    }
}