using System;
using System.Collections.Generic;
using System.Text;

namespace TaxApi.Domain.Entities
{
    /// <summary>
    /// Tax Line Item
    /// </summary>
    public class TaxLineItem
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Taxable Amount
        /// </summary>
        public int Taxable_amount { get; set; }

        /// <summary>
        /// Tax Collectable
        /// </summary>
        public double Tax_collectable { get; set; }

        /// <summary>
        /// Combined Tax Rate
        /// </summary>
        public double Combined_tax_rate { get; set; }

        /// <summary>
        /// State Taxable Amount
        /// </summary>
        public int State_taxable_amount { get; set; }

        /// <summary>
        /// State sales tax rate
        /// </summary>
        public double State_sales_tax_rate { get; set; }

        /// <summary>
        /// State Amount
        /// </summary>
        public double State_amount { get; set; }

        /// <summary>
        /// County Taxable Amount
        /// </summary>
        public int County_taxable_amount { get; set; }

        /// <summary>
        /// County Tax Rate
        /// </summary>
        public double County_tax_rate { get; set; }

        /// <summary>
        /// County Amount
        /// </summary>
        public double County_amount { get; set; }

        /// <summary>
        /// City Taxable Amount
        /// </summary>
        public int City_taxable_amount { get; set; }

        /// <summary>
        /// City Tax Rate
        /// </summary>
        public int City_tax_rate { get; set; }

        /// <summary>
        /// City Amount
        /// </summary>
        public int City_amount { get; set; }

        /// <summary>
        /// Special District Taxable Amount
        /// </summary>
        public int Special_district_taxable_amount { get; set; }

        /// <summary>
        /// Special Tax Rate
        /// </summary>
        public double Special_tax_rate { get; set; }

        /// <summary>
        /// Special District Amount
        /// </summary>
        public double Special_district_amount { get; set; }
    }
}
