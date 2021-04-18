using System;
using System.Collections.Generic;
using System.Text;

namespace TaxApi.Domain.Entities
{
    /// <summary>
    /// Jurisdictions
    /// </summary>
    public class Jurisdictions
    {
        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }
    }
}
