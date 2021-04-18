using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TaxApi.Core.Repository;
using TaxApi.Core.Service;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Xunit;
using TaxApi.ApiClient;
using TaxApi.Domain;

namespace TaxApi.Core_Tests.Controller
{
    public class TaxRepositoryUnitTests
    {

        private Mock<ILogger<TaxRepository>> _mockLogger;
        private Mock<ITaxService> _mockTaxService;
        private Mock<IApiClient> _mockApiClient;
        private TaxRepository _repository;

        public TaxRepositoryUnitTests()
        {
            _mockLogger = new Mock<ILogger<TaxRepository>>();
            _mockTaxService = new Mock<ITaxService>();
            _mockApiClient = new Mock<IApiClient>();
            _repository = new TaxRepository(_mockApiClient.Object,_mockLogger.Object);
        }

        [Fact]
        public async Task GetTaxRate_Expect_SuccessAsync()
        {
            //arrange
            _mockApiClient.Setup(x=>x.ApiCall<TaxRateResponse>(HttpMethod.Get, It.IsAny<string>(),It.IsAny<string>(), It.IsAny<string>(),null)).Returns(Task.FromResult(new TaxRateResponse()
            {
                Rate = new Domain.Entities.Rate()
                {
                    Zip = "33712",
                    City = "St Petesburg",
                    City_rate = "10",
                    County = "US",
                    Combined_district_rate = "10",
                    Combined_rate = "10",
                    County_rate = "10",
                    Freight_taxable = false,
                    State = "FL",
                    State_rate = "7"
                }
            })).Verifiable();

            //act
            var actual = await _repository.GetTaxRate(new Domain.TaxRateApiRequest());

            //assert
            Assert.NotNull(actual);
            _mockApiClient.Verify();
            Assert.Equal("33712", actual.Rate.Zip);
        }


        [Fact]
        public async Task CalcualteOrderTax_Expect_SuccessAsync()
        {
            //arrange
            _mockApiClient.Setup(x => x.ApiCall<OrderTaxResponse>(HttpMethod.Post, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>())).Returns(Task.FromResult(new OrderTaxResponse()
            {
                
                Tax = new Domain.Entities.Tax()
                {
                    Rate = 10,
                    Amount_to_collect = 10,
                    Taxable_amount = 50,
                    Order_total_amount = 1000,
                    Shipping = 20
                }
            })).Verifiable();

            //act
            var actual = await _repository.TaxForOrder(new Domain.OrderTaxApiRequest());

            //assert
            Assert.NotNull(actual);
            _mockApiClient.Verify();
            Assert.Equal(10, actual.Tax.Rate);
            Assert.Equal(20, actual.Tax.Shipping);
        }
    }
}
