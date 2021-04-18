using System;
using System.Collections.Generic;
using TaxApi.Domain.Entities;

namespace TaxApi.Domain
{
    /// <summary>
    /// Order Tax Response
    /// </summary>
    public class OrderTaxResponse
    {
        /// <summary>
        /// Tax Info Object
        /// </summary>
        public Tax Tax { get; set; }
    }
    
   
}
