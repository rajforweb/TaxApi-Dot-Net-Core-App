using System;
using System.Threading.Tasks;
using TaxApi.Domain;

namespace TaxApi.Core.Repository
{
    public interface ITaxRepository
    {

        Task<TaxRateResponse> GetTaxRate(TaxRateApiRequest apiRequest);

        Task<OrderTaxResponse> TaxForOrder(OrderTaxApiRequest apiRequest);

    }
}
