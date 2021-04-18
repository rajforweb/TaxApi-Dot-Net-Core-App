using System;
using TaxApi.Core.Service;
using TaxApi.Host.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using TaxApi.Domain;
using System.Threading.Tasks;
using TaxApi.Exceptions;

namespace TaxApi.Core_Tests.Controller
{
    public class TaxControllerUnitTests
    {

        private Mock<ILogger<TaxController>> _mockLogger;
        private Mock<ITaxService> _mockTaxService;

        private TaxController _controller;

        public TaxControllerUnitTests()
        {
            _mockLogger = new Mock<ILogger<TaxController>>();
            _mockTaxService = new Mock<ITaxService>();
            _controller = new TaxController(_mockLogger.Object, _mockTaxService.Object);
        }

        [Fact]
        public async Task GetTaxRate_Valid_Request_Expect_SuccessAsync()
        {
            //arrange

            _mockTaxService.Setup(x => x.GetTaxRate(It.IsAny<TaxRateRequest>())).Returns(Task.FromResult(new TaxRateResponse()
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
            var actual = await _controller.GetTaxRate(new TaxRateRequest() { Zip = "33712" }) as OkObjectResult;

            var data = actual.Value as TaxRateResponse;

            //assert
            Assert.NotNull(actual);
            _mockTaxService.Verify();
            Assert.Equal("33712", data.Rate.Zip);
        }

        [Fact]
        public async Task GetTaxRate_InValid_Request_Expect_Error()
        {
            //arrange
            //arrange

            _mockTaxService.Setup(x => x.GetTaxRate(It.IsAny<TaxRateRequest>())).Throws(new BadInputException("InVlid.Zip"));

            //act and Expect error
            var ex = await Assert.ThrowsAsync<BadInputException>(() => _controller.GetTaxRate(new TaxRateRequest()));

            _mockTaxService.Verify();

        }


        [Fact]
        public async Task OrderTax_Valid_Request_Expect_SuccessAsync()
        {
            //arrange

            _mockTaxService.Setup(x => x.TaxForOrder(It.IsAny<OrderTaxRequest>())).Returns(Task.FromResult(new OrderTaxResponse()
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
            var actual = await _controller.OrderTax(new OrderTaxRequest() { Shipping = 20, From_country = "US", To_country = "UK" }) as OkObjectResult;

            var data = actual.Value as OrderTaxResponse;

            //assert
            Assert.NotNull(actual);
            _mockTaxService.Verify();
            Assert.Equal(10, data.Tax.Rate);
            Assert.Equal(20, data.Tax.Shipping);
        }

        [Fact]
        public async Task OrderTax_InValid_Request_Expect_SuccessAsync()
        {
            //arrange

            _mockTaxService.Setup(x => x.TaxForOrder(It.IsAny<OrderTaxRequest>())).Throws(new BadInputException("InVlid.From_country"));

            //act and Expect error
            var ex = await Assert.ThrowsAsync<BadInputException>(() => _controller.OrderTax(new OrderTaxRequest()));

            _mockTaxService.Verify();

        }

    }
}
