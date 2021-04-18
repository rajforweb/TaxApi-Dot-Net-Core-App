using System;
using System.Collections.Generic;
using System.Text;

namespace TaxApi.Domain.Entities
{
    public class Breakdown
    {
        public int Taxable_amount { get; set; }
        public double Tax_collectable { get; set; }
        public double Combined_tax_rate { get; set; }
        public int State_taxable_amount { get; set; }
        public double State_tax_rate { get; set; }
        public double State_tax_collectable { get; set; }
        public int County_taxable_amount { get; set; }
        public double County_tax_rate { get; set; }
        public double County_tax_collectable { get; set; }
        public int City_taxable_amount { get; set; }
        public int City_tax_rate { get; set; }
        public int City_tax_collectable { get; set; }
        public int Special_district_taxable_amount { get; set; }
        public double Special_tax_rate { get; set; }
        public double Special_district_tax_collectable { get; set; }
        public List<TaxLineItem> Line_items { get; set; }
    }

}
