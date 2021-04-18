using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using TaxApi.Domain.Common;
using TaxApi.Exceptions;

namespace TaxApi.ApiClient
{
    public class TaxApiClient : IApiClient
    {
        private readonly ILogger<TaxApiClient> _logger;
        private readonly IHttpClientFactory _httpFactory;
        private const string MediaType = "application/json";

        public JsonMediaTypeFormatter JsonFormatter { get; set; } = new JsonMediaTypeFormatter()
        {
            SerializerSettings =
             {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
             }
        };

        public TaxApiClient(IHttpClientFactory httpFactory, ILogger<TaxApiClient> logger)
        {
            _logger = logger;
            _httpFactory = httpFactory;
        }

        /// <summary>
        /// Calls Configured API as per need. This is generic method supports GET POST PUT etc... 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpMethod"></param>
        /// <param name="apiBaseUrl"></param>
        /// <param name="uri"></param>
        /// <param name="apiToken"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<T> ApiCall<T>(HttpMethod httpMethod, string apiBaseUrl, string uri, string apiToken,object body=null)
        {
            try
            {
                HttpResponseMessage response = null;

                var httpclient = _httpFactory.CreateClient();

                using (var request = CreateJsonRequest(httpMethod, apiBaseUrl, uri, apiToken,body))
                {
                    response = await httpclient.SendAsync(request);
                   
                    if (response.IsSuccessStatusCode)
                    {
                        T value = await response.Content.ReadAsAsync<T>();
                        return value;
                    }
                    else
                    {
                        ApiErrorInfo apiErrorInfo = await response.Content.ReadAsAsync<ApiErrorInfo>();

                        switch (apiErrorInfo.Status)
                        {
                            case "406":
                                throw new BadInputException(apiErrorInfo.Detail);
                            default:
                                throw new ApiException(apiErrorInfo.Detail);

                        }
                        
                    }  
                }

                _logger.LogWarning($"ApiCall: StatusCode={response.StatusCode}");

                return default(T);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ApiCall: Exception={ex}");
                throw ex;
            }
        }

        /// <summary>
        /// Method to create Json request and adds authorization to the header
        /// </summary>
        /// <param name="httpMethod"></param>
        /// <param name="baseAddress"></param>
        /// <param name="uri"></param>
        /// <param name="apiSecret"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        private HttpRequestMessage CreateJsonRequest(HttpMethod httpMethod, string baseAddress, string uri, string apiSecret, object spec = null)
        {
            var request = new HttpRequestMessage(httpMethod, new Uri($"{baseAddress}/{uri}"));

            if (httpMethod == HttpMethod.Put || httpMethod == HttpMethod.Post)
            {
                var data = JsonConvert.SerializeObject(spec, Formatting.None, JsonFormatter.SerializerSettings);
                request.Content = new StringContent(data, Encoding.UTF8, MediaType);
            }

            request.Headers.Add("Authorization", "Bearer " + apiSecret);
   
            return request;
        }
    }
}
