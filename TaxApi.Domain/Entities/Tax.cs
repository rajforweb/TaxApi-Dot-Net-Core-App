using System;
using System.Collections.Generic;
using System.Text;

namespace TaxApi.Domain.Entities
{
    /// <summary>
    /// Tax
    /// </summary>
    public class Tax
    {
        /// <summary>
        /// Order total amount
        /// </summary>
        public double Order_total_amount { get; set; }

        /// <summary>
        /// Shipping
        /// </summary>
        public double Shipping { get; set; }

        /// <summary>
        /// Taxable Amount
        /// </summary>
        public int Taxable_amount { get; set; }

        /// <summary>
        /// Amount to collect
        /// </summary>
        public double Amount_to_collect { get; set; }

        /// <summary>
        /// Rate amount
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// Has nexus flag
        /// </summary>
        public bool Has_nexus { get; set; }

        /// <summary>
        /// Taxable Freight
        /// </summary>
        public bool Freight_taxable { get; set; }

        /// <summary>
        /// Tax Source
        /// </summary>
        public string Tax_source { get; set; }

        /// <summary>
        ///  Jurisdictions Object
        /// </summary>
        public Jurisdictions Jurisdictions { get; set; }

        /// <summary>
        /// Breakdown Object
        /// </summary>
        public Breakdown Breakdown { get; set; }
    }
}
