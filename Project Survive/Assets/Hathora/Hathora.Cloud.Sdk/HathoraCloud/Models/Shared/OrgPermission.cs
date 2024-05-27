
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
    public class OrgPermission
    {

        [SerializeField]
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; } = default!;

        /// <summary>
        /// System generated unique identifier for a user. Not guaranteed to have a specific format.
        /// </summary>
        [SerializeField]
        [JsonProperty("invitedBy")]
        public string InvitedBy { get; set; } = default!;

        /// <summary>
        /// System generated unique identifier for an organization. Not guaranteed to have a specific format.
        /// </summary>
        [SerializeField]
        [JsonProperty("orgId")]
        public string OrgId { get; set; } = default!;

        [SerializeField]
        [JsonProperty("status")]
        public OrganizationInviteStatus Status { get; set; } = default!;

        [SerializeField]
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; } = default!;

        [SerializeField]
        [JsonProperty("userEmail")]
        public string UserEmail { get; set; } = default!;
    }
}