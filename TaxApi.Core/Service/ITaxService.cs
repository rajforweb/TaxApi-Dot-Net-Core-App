using System;
using System.Threading.Tasks;
using TaxApi.Domain;

namespace TaxApi.Core.Service
{
    public interface ITaxService
    {
        Task<TaxRateResponse> GetTaxRate(TaxRateRequest taxRateRequest);

        Task<OrderTaxResponse> TaxForOrder(OrderTaxRequest orderTax);     
    }
}
