using System;
using System.Collections.Generic;
using System.Text;

namespace TaxApi.Domain.Entities
{
    /// <summary>
    /// OrderLineItem
    /// </summary>
    public class OrderLineItem
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Product_tax_code
        /// </summary>
        public string Product_tax_code { get; set; }

        /// <summary>
        /// Unit_price
        /// </summary>
        public int Unit_price { get; set; }

        /// <summary>
        /// Discount
        /// </summary>
        public int Discount { get; set; }
    }
}
