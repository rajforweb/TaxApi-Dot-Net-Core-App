using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TaxApi.ApiClient
{
    public interface IApiClient
    {
        Task<T> ApiCall<T>(HttpMethod httpMethod, string apiBaseUrl, string uri, string apiToken, object body = null);
    }
}
