using System;
using TaxApi.ApiClient;
using TaxApi.Core.Repository;
using TaxApi.Core.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaxApi.Validator;
using Microsoft.AspNetCore.Authentication;
using TaxApi.Host.Filters;
using TaxApi.Helpers;
using TaxApi.Filters;

namespace TaxApi.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(s =>
                s.OperationFilter<ConsumerHeaderFilter>()
            ); 

            services.AddHttpClient();
            services.AddHttpContextAccessor();
         
            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(ErrorExceptionFilter));
            });

            services.AddSingleton<ITaxRepository, TaxRepository>();
            services.AddSingleton<ITaxService, TaxService>();        
            services.AddSingleton<ITaxServiceValidator, TaxServiceValidator>();
            services.AddSingleton<IApiClient, TaxApiClient>();
            services.AddSingleton<IConsumerHelper, ConsumerHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Documentation");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
