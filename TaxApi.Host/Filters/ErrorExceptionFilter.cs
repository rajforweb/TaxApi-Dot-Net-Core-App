using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using TaxApi.Domain.Common;
using TaxApi.Exceptions;

namespace TaxApi.Host.Filters
{
    /// <summary>
    /// Error Exception Filter :  Catch all errors and returns Appropriate Error response
    /// </summary>
    public class ErrorExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ErrorExceptionFilter> _logger;
        public ErrorExceptionFilter(ILogger<ErrorExceptionFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Catch Exception and returns response
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {

                case BadInputException ex:
                    context.Result = CreateExceptionInfoResponse(context, ex.Errors, Constants.BadRequest, HttpStatusCode.BadRequest);
                    break;

                case ApiException ex:
                    context.Result = CreateExceptionInfoResponse(context, ex.Errors, Constants.InteralServerError, HttpStatusCode.InternalServerError);
                    break;

                case Exception ex:
                    context.Result = CreateExceptionInfoResponse(context, null, Constants.InteralServerError, HttpStatusCode.InternalServerError);
                    break;

            }
        }


        /// <summary>
        /// Creates Exception Info Response
        /// </summary>
        /// <param name="context"></param>
        /// <param name="errors"></param>
        /// <param name="errorConstant"></param>
        /// <param name="httpStatusCode"></param>
        /// <returns></returns>
        private IActionResult CreateExceptionInfoResponse(ActionContext context, IEnumerable<string> errors, string errorConstant, HttpStatusCode httpStatusCode)
        {
            if (errors == null || errors.Any(x => String.IsNullOrWhiteSpace(x)))
            {
                errors = new List<string> { errorConstant };
            }

            var errorInfo = new ErrorInfoResponse() { Messages = new List<ErrorMessage>() };

            foreach (var error in errors)
            {
                var errorMessage = new ErrorMessage()
                {
                    Code = $"TaxApi.{error}",
                    Message = $"TaxApi.{error}"
                };

                errorInfo.Messages.Add(errorMessage);
            }

            var result = new ObjectResult(errorInfo) { StatusCode = (int)httpStatusCode };
            _logger.LogError($"Error = {result.StatusCode}");

            return result;
        }
    }


}
