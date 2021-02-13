using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MMTShop.Shared;
using MMTShop.Shared.Contracts;

namespace MMTShop.Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMediatR(typeof(Startup).Assembly)
                .AddSingleton<IDataAccess, DataAccess>()
                .AddSingleton<ApplicationSettings>()
                .AddScoped(ConfigureDbConnection)
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
