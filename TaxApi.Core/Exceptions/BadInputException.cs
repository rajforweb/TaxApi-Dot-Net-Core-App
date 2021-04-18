using System;
using System.Collections.Generic;
using System.Text;

namespace TaxApi.Exceptions
{
    public class BadInputException : Exception
    {
        public List<string> Errors { get; set; }

        public BadInputException(string error) : base(error)
        {
            Errors = new List<string> { error };
        }

        public BadInputException(List<string> errors) : base(string.Join(",", errors))
        {
            Errors = errors;
        }
    }
}
