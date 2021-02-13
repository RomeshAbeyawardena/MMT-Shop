using System;
using System.Data;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MMTShop.Server.Factories;
using MMTShop.Server.Pipelines.Behaviors;
using MMTShop.Server.Providers;
using MMTShop.Shared;
using MMTShop.Shared.Contracts;
using MMTShop.Shared.Contracts.Provider;

namespace MMTShop.Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var currentAssembly = typeof(Startup).Assembly;

            services
                .AddValidatorsFromAssembly(currentAssembly)
                .AddMediatR(currentAssembly)
                .AddSingleton<IDataAccess, DataAccess>()
                .AddSingleton<ApplicationSettings>()
                .AddScoped<IValidatorFactory, DefaultValidatorFactory>()
                .AddScoped<ICategoryProvider, CategoryProvider>()
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidateRequestRequestPreProcessor<,>))
                .AddScoped(ConfigureDbConnection)
                .AddLogging()
                .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }

        
        private IDbConnection ConfigureDbConnection(IServiceProvider serviceProvider)
        {
            var applicationSettings = serviceProvider
                .GetRequiredService<ApplicationSettings>();

            var sqlConnection = new SqlConnection(applicationSettings
                .DefaultConnectionString);

            sqlConnection.Open();

            return sqlConnection;
        }

    }
}
