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
        public decimal Taxable_amount { get; set; }

        /// <summary>
        /// Tax Collectable
        /// </summary>
        public decimal Tax_collectable { get; set; }

        /// <summary>
        /// Combined Tax Rate
        /// </summary>
        public decimal Combined_tax_rate { get; set; }

        /// <summary>
        /// State Taxable Amount
        /// </summary>
        public decimal State_taxable_amount { get; set; }

        /// <summary>
        /// State sales tax rate
        /// </summary>
        public decimal State_sales_tax_rate { get; set; }

        /// <summary>
        /// State Amount
        /// </summary>
        public decimal State_amount { get; set; }

        /// <summary>
        /// County Taxable Amount
        /// </summary>
        public decimal County_taxable_amount { get; set; }

        /// <summary>
        /// County Tax Rate
        /// </summary>
        public decimal County_tax_rate { get; set; }

        /// <summary>
        /// County Amount
        /// </summary>
        public decimal County_amount { get; set; }

        /// <summary>
        /// City Taxable Amount
        /// </summary>
        public decimal City_taxable_amount { get; set; }

        /// <summary>
        /// City Tax Rate
        /// </summary>
        public decimal City_tax_rate { get; set; }

        /// <summary>
        /// City Amount
        /// </summary>
        public decimal City_amount { get; set; }

        /// <summary>
        /// Special District Taxable Amount
        /// </summary>
        public decimal Special_district_taxable_amount { get; set; }

        /// <summary>
        /// Special Tax Rate
        /// </summary>
        public decimal Special_tax_rate { get; set; }

        /// <summary>
        /// Special District Amount
        /// </summary>
        public decimal Special_district_amount { get; set; }
    }
}
