using System;
using System.Collections.Generic;
using System.Text;

namespace TaxApi.Domain.Common
{

    /// <summary>
    /// Error Response
    /// </summary>
    public class ErrorInfoResponse
    {
        public IList<ErrorMessage> Messages { get; set; }
    }

    /// <summary>
    /// Error Messages
    /// </summary>
    public class ErrorMessage
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
