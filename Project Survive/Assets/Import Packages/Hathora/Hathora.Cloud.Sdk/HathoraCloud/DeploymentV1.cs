
//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasyapi.dev). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace HathoraCloud
{
    using HathoraCloud.Models.Errors;
    using HathoraCloud.Models.Operations;
    using HathoraCloud.Models.Shared;
    using HathoraCloud.Utils;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System;
    using UnityEngine.Networking;

    /// <summary>
    /// Deprecated. Use <a href="https://hathora.dev/api#tag/DeploymentV2">DeploymentV2</a>.
    /// </summary>
    public interface IDeploymentV1
    {

        /// <summary>
        /// Create a new <a href="https://hathora.dev/docs/concepts/hathora-entities#deployment">deployment</a>. Creating a new deployment means all new rooms created will use the latest deployment configuration, but existing games in progress will not be affected.
        /// </summary>
        Task<CreateDeploymentDeprecatedResponse> CreateDeploymentDeprecatedAsync(CreateDeploymentDeprecatedRequest request);

        /// <summary>
        /// Get details for a <a href="https://hathora.dev/docs/concepts/hathora-entities#deployment">deployment</a>.
        /// </summary>
        Task<GetDeploymentInfoDeprecatedResponse> GetDeploymentInfoDeprecatedAsync(GetDeploymentInfoDeprecatedRequest request);

        /// <summary>
        /// Returns an array of <a href="https://hathora.dev/docs/concepts/hathora-entities#deployment">deployments</a> for an <a href="https://hathora.dev/docs/concepts/hathora-entities#application">application</a>.
        /// </summary>
        Task<GetDeploymentsDeprecatedResponse> GetDeploymentsDeprecatedAsync(GetDeploymentsDeprecatedRequest request);

        /// <summary>
        /// Get the latest <a href="https://hathora.dev/docs/concepts/hathora-entities#deployment">deployment</a> for an <a href="https://hathora.dev/docs/concepts/hathora-entities#application">application</a>.
        /// </summary>
        Task<GetLatestDeploymentDeprecatedResponse> GetLatestDeploymentDeprecatedAsync(GetLatestDeploymentDeprecatedRequest request);
    }

    /// <summary>
    /// Deprecated. Use <a href="https://hathora.dev/api#tag/DeploymentV2">DeploymentV2</a>.
    /// </summary>
    public class DeploymentV1: IDeploymentV1
    {
        public SDKConfig SDKConfiguration { get; private set; }
        private const string _target = "unity";
        private const string _sdkVersion = "0.29.0";
        private const string _sdkGenVersion = "2.326.3";
        private const string _openapiDocVersion = "0.0.1";
        private const string _userAgent = "speakeasy-sdk/unity 0.29.0 2.326.3 0.0.1 HathoraCloud";
        private string _serverUrl = "";
        private ISpeakeasyHttpClient _defaultClient;
        private Func<Security>? _securitySource;

        public DeploymentV1(ISpeakeasyHttpClient defaultClient, Func<Security>? securitySource, string serverUrl, SDKConfig config)
        {
            _defaultClient = defaultClient;
            _securitySource = securitySource;
            _serverUrl = serverUrl;
            SDKConfiguration = config;
        }
        

        [Obsolete("This method will be removed in a future release, please migrate away from it as soon as possible")]
        public async Task<CreateDeploymentDeprecatedResponse> CreateDeploymentDeprecatedAsync(CreateDeploymentDeprecatedRequest request)
        {
            if (request == null)
            {
                request = new CreateDeploymentDeprecatedRequest();
            }
            request.AppId ??= SDKConfiguration.AppId;
            
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = URLBuilder.Build(baseUrl, "/deployments/v1/{appId}/create/{buildId}", request);

            var httpRequest = new UnityWebRequest(urlString, UnityWebRequest.kHttpVerbPOST);
            DownloadHandlerStream downloadHandler = new DownloadHandlerStream();
            httpRequest.downloadHandler = downloadHandler;
            httpRequest.SetRequestHeader("user-agent", _userAgent);

            var serializedBody = RequestBodySerializer.Serialize(request, "DeploymentConfig", "json", false, false);
            if (serializedBody != null)
            {
                httpRequest.uploadHandler = new UploadHandlerRaw(serializedBody.Body);
                httpRequest.SetRequestHeader("Content-Type", serializedBody.ContentType);
            }

            var client = _defaultClient;
            if (_securitySource != null)
            {
                client = SecuritySerializer.Apply(_defaultClient, _securitySource);
            }

            var httpResponse = await client.SendAsync(httpRequest);
            int? errorCode = null;
            string? contentType = null;
            switch (httpResponse.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    errorCode = (int)httpRequest.responseCode;
                    contentType = httpRequest.GetResponseHeader("Content-Type");
                    httpRequest.Dispose();
                    break;
                case UnityWebRequest.Result.Success:
                    Console.WriteLine("Success");
                    break;
            }

            if (contentType == null)
            {
                contentType = httpResponse.GetResponseHeader("Content-Type") ?? "application/octet-stream";
            }
            int httpCode = errorCode ?? (int)httpResponse.responseCode;
            var response = new CreateDeploymentDeprecatedResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 201)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<Deployment>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    response.Deployment = obj;
                }
                else
                {
                throw new SDKException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (new List<int>{400, 401, 404, 429, 500}.Contains(httpCode))
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<ApiError>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    throw obj!;
                }
                else
                {
                throw new SDKException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (httpCode >= 400 && httpCode < 500 || httpCode >= 500 && httpCode < 600)
            {
                throw new SDKException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            else
            {
                throw new SDKException("unknown status code received", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            return response;
        }

        

        [Obsolete("This method will be removed in a future release, please migrate away from it as soon as possible")]
        public async Task<GetDeploymentInfoDeprecatedResponse> GetDeploymentInfoDeprecatedAsync(GetDeploymentInfoDeprecatedRequest request)
        {
            if (request == null)
            {
                request = new GetDeploymentInfoDeprecatedRequest();
            }
            request.AppId ??= SDKConfiguration.AppId;
            
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = URLBuilder.Build(baseUrl, "/deployments/v1/{appId}/info/{deploymentId}", request);

            var httpRequest = new UnityWebRequest(urlString, UnityWebRequest.kHttpVerbGET);
            DownloadHandlerStream downloadHandler = new DownloadHandlerStream();
            httpRequest.downloadHandler = downloadHandler;
            httpRequest.SetRequestHeader("user-agent", _userAgent);

            var client = _defaultClient;
            if (_securitySource != null)
            {
                client = SecuritySerializer.Apply(_defaultClient, _securitySource);
            }

            var httpResponse = await client.SendAsync(httpRequest);
            int? errorCode = null;
            string? contentType = null;
            switch (httpResponse.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    errorCode = (int)httpRequest.responseCode;
                    contentType = httpRequest.GetResponseHeader("Content-Type");
                    httpRequest.Dispose();
                    break;
                case UnityWebRequest.Result.Success:
                    Console.WriteLine("Success");
                    break;
            }

            if (contentType == null)
            {
                contentType = httpResponse.GetResponseHeader("Content-Type") ?? "application/octet-stream";
            }
            int httpCode = errorCode ?? (int)httpResponse.responseCode;
            var response = new GetDeploymentInfoDeprecatedResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<Deployment>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    response.Deployment = obj;
                }
                else
                {
                throw new SDKException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (new List<int>{401, 404}.Contains(httpCode))
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<ApiError>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    throw obj!;
                }
                else
                {
                throw new SDKException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (httpCode >= 400 && httpCode < 500 || httpCode >= 500 && httpCode < 600)
            {
                throw new SDKException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            else
            {
                throw new SDKException("unknown status code received", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            return response;
        }

        

        [Obsolete("This method will be removed in a future release, please migrate away from it as soon as possible")]
        public async Task<GetDeploymentsDeprecatedResponse> GetDeploymentsDeprecatedAsync(GetDeploymentsDeprecatedRequest request)
        {
            if (request == null)
            {
                request = new GetDeploymentsDeprecatedRequest();
            }
            request.AppId ??= SDKConfiguration.AppId;
            
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = URLBuilder.Build(baseUrl, "/deployments/v1/{appId}/list", request);

            var httpRequest = new UnityWebRequest(urlString, UnityWebRequest.kHttpVerbGET);
            DownloadHandlerStream downloadHandler = new DownloadHandlerStream();
            httpRequest.downloadHandler = downloadHandler;
            httpRequest.SetRequestHeader("user-agent", _userAgent);

            var client = _defaultClient;
            if (_securitySource != null)
            {
                client = SecuritySerializer.Apply(_defaultClient, _securitySource);
            }

            var httpResponse = await client.SendAsync(httpRequest);
            int? errorCode = null;
            string? contentType = null;
            switch (httpResponse.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    errorCode = (int)httpRequest.responseCode;
                    contentType = httpRequest.GetResponseHeader("Content-Type");
                    httpRequest.Dispose();
                    break;
                case UnityWebRequest.Result.Success:
                    Console.WriteLine("Success");
                    break;
            }

            if (contentType == null)
            {
                contentType = httpResponse.GetResponseHeader("Content-Type") ?? "application/octet-stream";
            }
            int httpCode = errorCode ?? (int)httpResponse.responseCode;
            var response = new GetDeploymentsDeprecatedResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<List<Deployment>>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    response.Classes = obj;
                }
                else
                {
                throw new SDKException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (new List<int>{401, 404}.Contains(httpCode))
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<ApiError>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    throw obj!;
                }
                else
                {
                throw new SDKException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (httpCode >= 400 && httpCode < 500 || httpCode >= 500 && httpCode < 600)
            {
                throw new SDKException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            else
            {
                throw new SDKException("unknown status code received", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            return response;
        }

        

        [Obsolete("This method will be removed in a future release, please migrate away from it as soon as possible")]
        public async Task<GetLatestDeploymentDeprecatedResponse> GetLatestDeploymentDeprecatedAsync(GetLatestDeploymentDeprecatedRequest request)
        {
            if (request == null)
            {
                request = new GetLatestDeploymentDeprecatedRequest();
            }
            request.AppId ??= SDKConfiguration.AppId;
            
            string baseUrl = this.SDKConfiguration.GetTemplatedServerDetails();
            var urlString = URLBuilder.Build(baseUrl, "/deployments/v1/{appId}/latest", request);

            var httpRequest = new UnityWebRequest(urlString, UnityWebRequest.kHttpVerbGET);
            DownloadHandlerStream downloadHandler = new DownloadHandlerStream();
            httpRequest.downloadHandler = downloadHandler;
            httpRequest.SetRequestHeader("user-agent", _userAgent);

            var client = _defaultClient;
            if (_securitySource != null)
            {
                client = SecuritySerializer.Apply(_defaultClient, _securitySource);
            }

            var httpResponse = await client.SendAsync(httpRequest);
            int? errorCode = null;
            string? contentType = null;
            switch (httpResponse.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    errorCode = (int)httpRequest.responseCode;
                    contentType = httpRequest.GetResponseHeader("Content-Type");
                    httpRequest.Dispose();
                    break;
                case UnityWebRequest.Result.Success:
                    Console.WriteLine("Success");
                    break;
            }

            if (contentType == null)
            {
                contentType = httpResponse.GetResponseHeader("Content-Type") ?? "application/octet-stream";
            }
            int httpCode = errorCode ?? (int)httpResponse.responseCode;
            var response = new GetLatestDeploymentDeprecatedResponse
            {
                StatusCode = httpCode,
                ContentType = contentType,
                RawResponse = httpResponse
            };
            if (httpCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<Deployment>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    response.Deployment = obj;
                }
                else
                {
                throw new SDKException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (new List<int>{401, 404}.Contains(httpCode))
            {
                if(Utilities.IsContentTypeMatch("application/json",response.ContentType))
                {                    
                    var obj = JsonConvert.DeserializeObject<ApiError>(httpResponse.downloadHandler.text, new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore, Converters = Utilities.GetDefaultJsonDeserializers() });
                    throw obj!;
                }
                else
                {
                throw new SDKException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
                }
            }
            else if (httpCode >= 400 && httpCode < 500 || httpCode >= 500 && httpCode < 600)
            {
                throw new SDKException("API error occurred", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            else
            {
                throw new SDKException("unknown status code received", httpCode, httpResponse.downloadHandler.text, httpResponse);
            }
            return response;
        }

        
    }
}