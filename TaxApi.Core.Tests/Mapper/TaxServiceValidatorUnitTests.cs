using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using TaxApi.Validator;

namespace TaxApi.Core_Tests.Controller
{
    public class TaxServiceValidatorUnitTests
    {

        private Mock<ILogger<TaxServiceValidator>> _mockLogger;
   
        private TaxServiceValidator _validator;

        public TaxServiceValidatorUnitTests()
        {
            _mockLogger = new Mock<ILogger<TaxServiceValidator>>();
            _validator = new TaxServiceValidator(_mockLogger.Object);
        }

        [Fact]
        public void ValidateTaxRate_DoesNot_Throw_Exception_Success()
        {
            //arrange

            //act
            _validator.ValidateTaxRateRequest(new Domain.TaxRateRequest() { Zip ="33712"});


            //assert
        }

        [Fact]
        public void ValidateOrderTax_DoesNot_Throw_Exception_Success()
        {
            //arrange

            //act
            _validator.ValidateOrderTaxRequest(new Domain.OrderTaxRequest() { To_country ="UK", Shipping=10});


            //assert
        }

    }
}
