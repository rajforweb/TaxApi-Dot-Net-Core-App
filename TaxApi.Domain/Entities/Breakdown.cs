using System;
using System.Collections.Generic;
using System.Text;

namespace TaxApi.Domain.Entities
{
    public class Breakdown
    {
        public decimal Taxable_amount { get; set; }
        public decimal Tax_collectable { get; set; }
        public decimal Combined_tax_rate { get; set; }
        public decimal State_taxable_amount { get; set; }
        public decimal State_tax_rate { get; set; }
        public decimal State_tax_collectable { get; set; }
        public decimal County_taxable_amount { get; set; }
        public decimal County_tax_rate { get; set; }
        public decimal County_tax_collectable { get; set; }
        public decimal City_taxable_amount { get; set; }
        public decimal City_tax_rate { get; set; }
        public decimal City_tax_collectable { get; set; }
        public decimal Special_district_taxable_amount { get; set; }
        public decimal Special_tax_rate { get; set; }
        public decimal Special_district_tax_collectable { get; set; }
        public List<TaxLineItem> Line_items { get; set; }
    }

}
