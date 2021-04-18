using TaxApi.Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TaxApi.Domain;
using Microsoft.AspNetCore.Authorization;
using TaxApi.Attributes;

namespace TaxApi.Host.Controllers
{

    /// <summary>
    /// Tax Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ILogger<TaxController> _logger;
        private readonly ITaxService _taxService;
        public TaxController(ILogger<TaxController> logger, ITaxService taxService)
        {
            _logger = logger;
            _taxService = taxService;
        }


        /// <summary>
        /// Get Tax Rate 
        /// </summary>
        /// <returns></returns>
        [Route("TaxRate")]
        [HttpGet]
        [ConsumerSecurityFilter]
        public async Task<IActionResult> GetTaxRate([FromQuery] TaxRateRequest taxRateRequest)
        {
            var getTaxRateResponse = await _taxService.GetTaxRate(taxRateRequest);
            return Ok(getTaxRateResponse);
        }


        /// <summary>
        /// Calculates Tax for an Order
        /// </summary>
        /// <returns></returns>
        [HttpPost("OrderTax")]
        [ConsumerSecurityFilter]
        public async Task<IActionResult> OrderTax([FromBody] OrderTaxRequest orderTax)
        {
            var getTaxForOrder = await _taxService.TaxForOrder(orderTax);
            return Ok(getTaxForOrder);
        }

    }
}
