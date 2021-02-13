using System;
using System.Data;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MMTShop.Server.Factories;
using MMTShop.Server.Features.Category;
using MMTShop.Server.Features.Product;
using MMTShop.Server.Pipelines.Behaviors;
using MMTShop.Shared;
using MMTShop.Shared.Contracts;
using MMTShop.Shared.Contracts.Provider;
using MMTShop.Shared.Contracts.Repository;

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
                .AddSingleton<IDatabaseQueryProvider, DatabaseQueryProvider>()
                .AddSingleton<ApplicationSettings>()
                .AddSingleton<ISystemClock, SystemClock>()
                .AddScoped<IValidatorFactory, DefaultValidatorFactory>()
                .AddScoped<ICategoryProvider, CategoryProvider>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped(ConfigureDbConnection)
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidateRequestRequestPreProcessor<,>))
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
                    await context.Response.WriteAsync("MMT Shop Server");
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
