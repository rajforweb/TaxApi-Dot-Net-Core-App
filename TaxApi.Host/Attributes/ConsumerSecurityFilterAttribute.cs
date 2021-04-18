using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxApi.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net;
using TaxApi.Domain.Common;

namespace TaxApi.Attributes
{
    public class ConsumerSecurityFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var svc = context.HttpContext.RequestServices;

            var consumerHelper = svc.GetService<IConsumerHelper>();

            if (consumerHelper.ValidateConsumer())
                return;

            context.Result = UnAuthorizedExceptionInfoResponse();
        }


        private IActionResult UnAuthorizedExceptionInfoResponse()
        {
            var errorInfo = new ErrorInfoResponse() { Messages = new List<ErrorMessage>() };
            var errorMessage = new ErrorMessage()
            {
                Code = $"TaxApi.UnAuthorized",
                Message = $"TaxApi.UnAuthorized"
            };

            errorInfo.Messages.Add(errorMessage);


            var result = new ObjectResult(errorInfo) { StatusCode = (int)HttpStatusCode.Unauthorized };
           
            return result;
        }
    }
}
