using System;
using System.Collections.Generic;
using System.Text;

namespace TaxApi.Domain.Common
{
    public class ApiErrorInfo
    {
        /// <summary>
        /// Response Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Response Error
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Response Error Detail
        /// </summary>
        public string Detail { get; set; }
    }
}
