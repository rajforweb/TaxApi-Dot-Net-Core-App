using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxApi.Domain.Entities;

namespace TaxApi.Domain
{
    /// <summary>
    /// TaxRate Request
    /// </summary>
    public class TaxRateRequest
    {

        /// <summary>
        /// Zip
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }


        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

    }
}
