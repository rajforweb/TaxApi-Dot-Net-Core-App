using System.Threading.Tasks;
using TaxApi.Core.Repository;
using TaxApi.Domain;
using Microsoft.Extensions.Logging;
using TaxApi.Validator;
using TaxApi.Helpers;
using System.Collections.Generic;
using System;
using TaxApi.Domain.Entities;

namespace TaxApi.Core.Service
{
    /// <summary>
    /// Tax Service - Service Layer to validate requests. Services capable of making atleast one respository and return response 
    /// </summary>
    public class TaxService : ITaxService
    {
        private readonly ITaxRepository _taxRepository;
        private readonly ITaxServiceValidator _taxServiceValidator;
        private readonly ILogger<TaxService> _logger;
        private readonly IConsumerHelper _consumerHelper;

        /// <summary>
        /// TaxService Constructor
        /// </summary>
        /// <param name="taxRepository"></param>
        /// <param name="taxServiceValidator"></param>
        /// <param name="logger"></param>
        public TaxService(ITaxRepository taxRepository, ITaxServiceValidator taxServiceValidator, IConsumerHelper consumerHelper, ILogger<TaxService> logger)
        {
            _taxRepository = taxRepository;
            _logger = logger;
            _taxServiceValidator = taxServiceValidator;
            _consumerHelper = consumerHelper;
        }


        /// <summary>
        /// Method to Calculate Order Tax
        /// </summary>
        /// <returns></returns>
        public async Task<OrderTaxResponse> TaxForOrder(OrderTaxRequest orderTax)
        {
            //Validate request and consumer
            _taxServiceValidator.ValidateOrderTaxRequest(orderTax);

            //Get Consumer Details
            var consumerDetail = _consumerHelper.GetConsumer();

            //Create api request
            var apiRequest = new OrderTaxApiRequest()
            {
                //required
                To_country = orderTax.To_country,
                Shipping = orderTax.Shipping,
                From_country = orderTax.From_country,
                ////optional
                From_zip = orderTax.From_zip,
                From_city = orderTax.From_city,
                From_state = orderTax.From_state,
                From_street = orderTax.From_street,

                To_city = orderTax.To_city,
                To_street = orderTax.To_street,
                Amount = orderTax.Amount,
                Nexus_addresses = MapAddress(orderTax.Nexus_addresses),
                Line_items = MaplineItem(orderTax.Line_items),

                ////conditional
                To_zip = orderTax.To_zip,
                To_state = orderTax.To_state,

                TaxApiAuthToken = consumerDetail.TaxApiAuthToken,
                TaxApiUrl = consumerDetail.TaxApiUrl
            };

            //Call repository with valid request
            var response = await _taxRepository.TaxForOrder(apiRequest);

            return response;
        }

       
        /// <summary>
        /// Method to Find Tax Rate
        /// </summary>
        /// <returns></returns>
        public async Task<TaxRateResponse> GetTaxRate(TaxRateRequest taxRateRequest)
        {
            //validate request
            _taxServiceValidator.ValidateTaxRateRequest(taxRateRequest);

            //Get Consumer Details
            var consumerDetail = _consumerHelper.GetConsumer();

            //Create api request
            var TaxRateResponseRequest = new TaxRateApiRequest()
            {
                Zip = taxRateRequest.Zip,
                City = taxRateRequest.City,
                Country = taxRateRequest.Country,
                State = taxRateRequest.State,
                Street = taxRateRequest.Street,
                TaxApiAuthToken = consumerDetail.TaxApiAuthToken,
                TaxApiUrl = consumerDetail.TaxApiUrl
            };

            //Call repository with valid request
            var response = await _taxRepository.GetTaxRate(TaxRateResponseRequest);

            return response;
        }

        #region Private methods

        /// <summary>
        /// MaplineItem 
        /// </summary>
        /// <param name="line_items"></param>
        /// <returns></returns>
        private List<OrderLineItem> MaplineItem(List<OrderLineItem> line_items)
        {
            if (line_items == null)
                return null;

            var lineItems = new List<OrderLineItem>();

            foreach (var item in line_items)
            {
                lineItems.Add(new OrderLineItem()
                {
                    Discount = item.Discount,
                    Id = item.Id,
                    Product_tax_code = item.Product_tax_code,
                    Quantity = item.Quantity,
                    Unit_price = item.Unit_price
                });
            }

            return lineItems;
        }

        /// <summary>
        /// Map Address
        /// </summary>
        /// <param name="nexus_addresses"></param>
        /// <returns></returns>
        private List<NexusAddress> MapAddress(List<NexusAddress> nexus_addresses)
        {
            if (nexus_addresses == null)
                return null;

            var addresses = new List<NexusAddress>();

            foreach (var item in nexus_addresses)
            {
                addresses.Add(new NexusAddress()
                {
                    City = item.City,
                    Country = item.Country,
                    Id = item.Id,
                    State = item.State,
                    Street = item.Street,
                    Zip = item.Zip
                });
            }
            return addresses;
        }
        #endregion
    }
}
