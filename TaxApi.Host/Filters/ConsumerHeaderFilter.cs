using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxApi.Filters
{
    public class ConsumerHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "ConsumerKey",
                In = ParameterLocation.Header,
                Description = "Enter Consumer Key e.g. f4b358d793ce4105b46d9f055cf53f79",
                Schema = new OpenApiSchema
                {
                    Type = "string"
                },
                Required = true,                
            });
        }
    }
}
