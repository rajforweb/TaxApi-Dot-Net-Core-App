using System;
using System.Collections.Generic;
using System.Text;

namespace TaxApi.Domain.Entities
{
    /// <summary>
    /// NexusAddress
    /// </summary>
    public class NexusAddress
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Zip
        /// </summary>
        public string Zip { get; set; }
        
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
    }

}
