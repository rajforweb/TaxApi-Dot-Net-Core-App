using System;
using TaxApi.Core.Repository;
using TaxApi.Core.Service;
using TaxApi.Domain;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using TaxApi.Validator;
using TaxApi.Helpers;
using System.Threading.Tasks;

namespace TaxApi.Core_Tests.Controller
{
    public class TaxServiceUnitTests
    {

        private Mock<ILogger<TaxService>> _mockLogger;
        private Mock<ITaxServiceValidator> _mockTaxServiceValidator;
        private Mock<IConsumerHelper> _mockConsumerHelper;
        private Mock<ITaxRepository> _mockTaxRepostory;
        private TaxService _service;

        public TaxServiceUnitTests()
        {
            _mockLogger = new Mock<ILogger<TaxService>>();
            _mockTaxServiceValidator = new Mock<ITaxServiceValidator>();
            _mockTaxRepostory = new Mock<ITaxRepository>();
            _mockConsumerHelper = new Mock<IConsumerHelper>();
            _service = new TaxService(_mockTaxRepostory.Object, _mockTaxServiceValidator.Object, _mockConsumerHelper.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetTaxRate_ValidRequest_Expect_SuccessAsync()
        {
            //arrange

            _mockTaxRepostory.Setup(x => x.GetTaxRate(It.IsAny<TaxRateApiRequest>())).Returns(Task.FromResult(new TaxRateResponse
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


            _mockTaxServiceValidator.Setup(x => x.ValidateTaxRateRequest(It.IsAny<TaxRateRequest>())).Verifiable();

            _mockConsumerHelper.Setup(x => x.GetConsumer()).Returns(new Domain.Entities.Consumer()
            {
                ConsumerKey = "IMC",
                TaxApiAuthToken = "testtoken",
                TaxApiUrl = "https://testaddress.com"
            }).Verifiable();

            //act
            var actual = await _service.GetTaxRate(new TaxRateRequest() { Zip= "33712" });

            //assert
            Assert.NotNull(actual);
            Assert.Equal("33712", actual.Rate.Zip);
            _mockConsumerHelper.Verify();
            _mockTaxServiceValidator.Verify();
            _mockTaxRepostory.Verify();

        }

        [Fact]
        public async Task CalculateOrderTax_ValidRequest_Expect_SuccessAsync()
        {
            //arrange

            _mockTaxRepostory.Setup(x => x.TaxForOrder(It.IsAny<OrderTaxApiRequest>())).Returns(Task.FromResult(new OrderTaxResponse
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


            _mockTaxServiceValidator.Setup(x => x.ValidateOrderTaxRequest(It.IsAny<OrderTaxRequest>())).Verifiable();

            _mockConsumerHelper.Setup(x => x.GetConsumer()).Returns(new Domain.Entities.Consumer()
            {
                ConsumerKey = "IMC",
                TaxApiAuthToken = "testtoken",
                TaxApiUrl = "https://testaddress.com"
            }).Verifiable();

            //act
            var actual = await _service.TaxForOrder(new OrderTaxRequest() { Shipping = 20, From_country = "US", To_country = "UK" });

            //assert
            Assert.NotNull(actual);
            Assert.Equal(10, actual.Tax.Rate);
            Assert.Equal(20, actual.Tax.Shipping);
            _mockConsumerHelper.Verify();
            _mockTaxServiceValidator.Verify();
            _mockTaxRepostory.Verify();

        }

    }
}
