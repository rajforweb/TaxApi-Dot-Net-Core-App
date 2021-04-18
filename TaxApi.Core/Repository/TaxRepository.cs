using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TaxApi.ApiClient;
using TaxApi.Domain;
using Microsoft.Extensions.Logging;

namespace TaxApi.Core.Repository
{
    /// <summary>
    /// TaxRepository - Repository Layer to call External Api using Apiclient Interface.
    /// </summary>
    public class TaxRepository : ITaxRepository  
    {
        private readonly ILogger<TaxRepository> _logger;
        private readonly IApiClient _apiClient;

        public TaxRepository(IApiClient apiClient, ILogger<TaxRepository> logger)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        /// <summary>
        /// Method to make Api call to get Tax Rate based on location
        /// </summary>
        /// <returns></returns>
        public async Task<TaxRateResponse> GetTaxRate(TaxRateApiRequest apiRequest)
        {
            var response = await _apiClient.ApiCall<TaxRateResponse>(HttpMethod.Get, apiRequest.TaxApiUrl, apiRequest.Uri,  apiRequest.TaxApiAuthToken);
            return response;
        }


        /// <summary>
        /// Method to make Api call for Order's rate
        /// </summary>
        /// <returns></returns>
        public async Task<OrderTaxResponse> TaxForOrder(OrderTaxApiRequest apiRequest)
        {
            var response = await _apiClient.ApiCall<OrderTaxResponse>(HttpMethod.Post, apiRequest.TaxApiUrl, apiRequest.Uri, apiRequest.TaxApiAuthToken, apiRequest);
            return response;
        }

    }
}
