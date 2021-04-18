using System;
using System.Collections.Generic;
using System.Text;

namespace TaxApi.Domain.Entities
{
    /// <summary>
    /// Rate
    /// </summary>
    public class Rate
    {
        /// <summary>
        /// Zip
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// State_rate
        /// </summary>
        public string State_rate { get; set; }

        /// <summary>
        /// County
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// County_rate
        /// </summary>
        public string County_rate { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// City_rate
        /// </summary>
        public string City_rate { get; set; }

        /// <summary>
        /// Combined_district_rate
        /// </summary>
        public string Combined_district_rate { get; set; }

        /// <summary>
        /// Combined_rate
        /// </summary>
        public string Combined_rate { get; set; }

        /// <summary>
        /// Freight_taxable
        /// </summary>
        public bool Freight_taxable { get; set; }
    }
}
