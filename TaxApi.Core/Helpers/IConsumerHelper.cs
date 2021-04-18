using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxApi.Domain;
using TaxApi.Domain.Entities;

namespace TaxApi.Helpers
{
    public interface IConsumerHelper
    {
        bool ValidateConsumer();
        Consumer GetConsumer();
    }
}
