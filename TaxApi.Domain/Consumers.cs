using System;
using System.Collections.Generic;
using System.Text;
using TaxApi.Domain.Entities;

namespace TaxApi.Domain
{
    /// <summary>
    /// Consumer Settings
    /// </summary>
    public class ConsumerSettings
    {
        /// <summary>
        /// List Of Consumers
        /// </summary>
        public List<Consumer> Consumers { get; set; }
    }
}
 