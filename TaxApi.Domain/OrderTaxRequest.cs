using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaxApi.Domain.Entities;

namespace TaxApi.Domain
{
    /// <summary>
    /// Order Tax Request
    /// </summary>
    public class OrderTaxRequest
    {
        /// <summary>
        /// From Country
        /// </summary>
        public string From_country { get; set; }

        /// <summary>
        /// From Zip
        /// </summary>
        public string From_zip { get; set; }

        /// <summary>
        /// From State
        /// </summary>
        public string From_state { get; set; }

        /// <summary>
        /// From City
        /// </summary>
        public string From_city { get; set; }
        
        /// <summary>
        /// From Street
        /// </summary>
        public string From_street { get; set; }

        /// <summary>
        /// To Country
        /// </summary>
        [Required]
        public string To_country { get; set; }

        /// <summary>
        /// To Zip
        /// </summary>
        public string To_zip { get; set; }

        /// <summary>
        /// To State
        /// </summary>
        public string To_state { get; set; }

        /// <summary>
        /// To City
        /// </summary>
        public string To_city { get; set; }

        /// <summary>
        /// To Street
        /// </summary>
        public string To_street { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Shipping
        /// </summary>
        [Required]
        public decimal Shipping { get; set; }

        /// <summary>
        /// Address Object
        /// </summary>
        public List<NexusAddress> Nexus_addresses { get; set; }

        /// <summary>
        /// Order Line Item
        /// </summary>
        public List<OrderLineItem> Line_items { get; set; }
    }

}
