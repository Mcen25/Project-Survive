
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
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class GetMetricsRequest
    {

        [SerializeField]
        [SpeakeasyMetadata("pathParam:style=simple,explode=false,name=processId")]
        public string ProcessId { get; set; } = default!;

        [SerializeField]
        [SpeakeasyMetadata("pathParam:style=simple,explode=false,name=appId")]
        public string? AppId { get; set; }

        /// <summary>
        /// Unix timestamp. Default is current time.
        /// </summary>
        [SerializeField]
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=end")]
        public double? End { get; set; }

        /// <summary>
        /// Available metrics to query over time.
        /// </summary>
        [SerializeField]
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=metrics")]
        public List<MetricName>? Metrics { get; set; }

        /// <summary>
        /// Unix timestamp. Default is -1 hour from `end`.
        /// </summary>
        [SerializeField]
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=start")]
        public double? Start { get; set; }

        [SerializeField]
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=step")]
        public int? Step { get; set; }
    }
}