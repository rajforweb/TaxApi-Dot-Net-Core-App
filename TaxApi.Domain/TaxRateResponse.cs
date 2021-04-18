using System;
using System.Collections.Generic;
using System.Text;
using TaxApi.Domain.Entities;

namespace TaxApi.Domain
{
    /// <summary>
    /// Tax Rate Response
    /// </summary>
    public class TaxRateResponse
    {
        /// <summary>
        /// Rate Object
        /// </summary>
        public Rate Rate { get; set; }
    }

}
