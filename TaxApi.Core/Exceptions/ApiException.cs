using System;
using System.Collections.Generic;
using System.Text;

namespace TaxApi.Exceptions
{
    public class ApiException : Exception
    {
        public List<string> Errors { get; set; }

        public ApiException(string error) : base(error)
        {
            Errors = new List<string> { error };
        }

        public ApiException(List<string> errors) : base(string.Join(",", errors))
        {
            Errors = errors;
        }
    }
}
