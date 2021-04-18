using System;
using System.Collections.Generic;
using System.Text;
using TaxApi.Domain;
using TaxApi.Domain.Entities;

namespace TaxApi.Validator
{
    public interface ITaxServiceValidator
    {
        void ValidateTaxRateRequest(TaxRateRequest request);

        void ValidateOrderTaxRequest(OrderTaxRequest request);
    }
}
