using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaxApi.ApiClient;
using TaxApi.Domain;
using Xunit;

namespace TaxApi.Core.Tests.ApiClientTests
{
    public class ApiClientUnitTests
    {
        private Mock<ILogger<TaxApiClient>> _logger;
        private Mock<IHttpClientFactory> _mockHttpFactory;
        private TaxApiClient apiClient;
        public ApiClientUnitTests()
        {
            _mockHttpFactory = new Mock<IHttpClientFactory>();
            _logger = new Mock<ILogger<TaxApiClient>>();
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{'rate':{'zip':'33712'} }", Encoding.UTF8, "application/json")
                });



            var client = new HttpClient(mockHttpMessageHandler.Object);
            _mockHttpFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

            apiClient = new TaxApiClient(_mockHttpFactory.Object, _logger.Object);
        }

        [Fact]
        public async Task ApiCall_SuccessAsync()
        {
            //arrange


            //act
            var result = await apiClient.ApiCall<TaxRateResponse> (HttpMethod.Get, "https://baseurl.com", "v2/test", "testToken", null) as TaxRateResponse;

            //assert
            Assert.NotNull(result);
            Assert.Equal("33712", result.Rate.Zip);

        }
    }
}
