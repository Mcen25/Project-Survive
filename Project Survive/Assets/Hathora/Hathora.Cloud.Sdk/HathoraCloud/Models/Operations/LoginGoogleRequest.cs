
//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasyapi.dev). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace HathoraCloud.Models.Operations
{
    using HathoraCloud.Models.Shared;
    using HathoraCloud.Utils;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class LoginGoogleRequest
    {

        [SerializeField]
        [SpeakeasyMetadata("request:mediaType=application/json")]
        public GoogleIdTokenObject GoogleIdTokenObject { get; set; } = default!;

        [SerializeField]
        [SpeakeasyMetadata("pathParam:style=simple,explode=false,name=appId")]
        public string? AppId { get; set; }
    }
}