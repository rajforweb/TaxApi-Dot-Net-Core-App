using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxApi.Domain;
using TaxApi.Domain.Common;
using TaxApi.Domain.Entities;
using TaxApi.Exceptions;

namespace TaxApi.Validator
{
    public class TaxServiceValidator : ITaxServiceValidator
    {

        private readonly ILogger<TaxServiceValidator> _logger;

        public TaxServiceValidator(ILogger<TaxServiceValidator> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Validate Request and Consumer
        /// </summary>
        /// <param name="zip"></param>
        public void ValidateTaxRateRequest(TaxRateRequest request)
        {
            if (string.IsNullOrEmpty(request.Zip))
                throw new BadInputException("Zip.NullOrEmpty");

        }

        /// <summary>
        /// Validates Order Tax request and Consumer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public void ValidateOrderTaxRequest(OrderTaxRequest request)
        {
            if (string.IsNullOrEmpty(request.To_country))
                throw new BadInputException("Invalid.To_country");
            if (request.Shipping == 0)
                throw new BadInputException("Invalid.Shipping");
        }
               
    }
}
