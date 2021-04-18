using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxApi.Domain;
using TaxApi.Domain.Common;
using TaxApi.Domain.Entities;
using TaxApi.Exceptions;

namespace TaxApi.Helpers
{
    public class ConsumerHelper : IConsumerHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ConsumerSettings _consumerSettings;
        private readonly IConfiguration _configuration;
        public ConsumerHelper(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _consumerSettings = JsonConvert.DeserializeObject<ConsumerSettings>(_configuration.GetSection(Constants.ConsumerSettings).Value);
        }

    
        /// <summary>
        /// Validate Consumer
        /// </summary>
        /// <returns></returns>

        public bool ValidateConsumer()
        {
            if (!_httpContextAccessor.HttpContext.Request.Headers.TryGetValue(Constants.ConsumerKey, out var consumerKey))
            {
                return false;
            }

            if (string.IsNullOrEmpty(consumerKey))
            {
                return false;
            }

            var consumerDetail = _consumerSettings.Consumers.FirstOrDefault(x => string.Equals(x.ConsumerKey, consumerKey, StringComparison.CurrentCultureIgnoreCase));

            if (consumerDetail == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates Consumer
        /// </summary>
        /// <returns></returns>
        public Consumer GetConsumer()
        {
            if (!_httpContextAccessor.HttpContext.Request.Headers.TryGetValue(Constants.ConsumerKey, out var consumerKey))
            {
                throw new BadInputException("Invalid.Consumer");
            }

            var consumerDetail = _consumerSettings.Consumers.FirstOrDefault(x => string.Equals(x.ConsumerKey, consumerKey, StringComparison.CurrentCultureIgnoreCase));

            return consumerDetail;
        }
    }
}
