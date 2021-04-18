using System;
using System.Collections.Generic;
using System.Text;

namespace TaxApi.Domain.Entities
{
    /// <summary>
    /// Consumer Configuration detail
    /// </summary>
    public class Consumer
    {
        /// <summary>
        /// Consumer Key
        /// </summary>
        public string ConsumerKey { get; set; }

  
        /// <summary>
        /// TaxApiUrl
        /// </summary>
        public string TaxApiUrl { get; set; }

        /// <summary>
        /// TaxApiAuthToken
        /// </summary>
        public string TaxApiAuthToken { get; set; }
    }
}
