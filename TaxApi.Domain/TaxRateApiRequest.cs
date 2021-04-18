using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxApi.Domain.Entities;

namespace TaxApi.Domain
{
    /// <summary>
    /// TaxRate ApiRequest
    /// </summary>
    public class TaxRateApiRequest : Consumer
    {
        /// <summary>
        /// UriValue 
        /// </summary>
        private string UriValue { get; set; }

        /// <summary>
        /// Uri
        /// </summary>
        public string Uri
        {
            get
            {
                UriValue = $"v2/rates/{Zip}";
                
                var list = new List<string>();
                if (!string.IsNullOrEmpty(Street))
                {
                    list.Add($"street={Street}");
                }
                if (!string.IsNullOrEmpty(City))
                {
                    list.Add($"city={City}");
                }
                if (!string.IsNullOrEmpty(State))
                {
                    list.Add($"state={State}");
                }
                if (!string.IsNullOrEmpty(Country))
                {
                    list.Add($"country={Country}");
                }


                if (list.Count > 0)
                {
                    string quaryparam = string.Join("&", list);

                    UriValue = $"{UriValue}?{quaryparam}";
                }

                return UriValue;
            }
        }

 
        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Zip
        /// </summary>
        public string Zip { get; set; }

    }
}
