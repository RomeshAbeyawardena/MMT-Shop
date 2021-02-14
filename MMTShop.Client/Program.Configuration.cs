using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMTShop.Client.Features.Category;
using MMTShop.Client.Features.Product;
using MMTShop.Client.Features.Quit;
using MMTShop.Shared;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShop.Client
{
    public partial class Program
    {
        private static IServiceCollection RegisterServices(
            IServiceCollection services,
            string baseUrl)
        {
            return services
                .AddSingleton<IConfiguration>((s) => new ConfigurationBuilder()
                    .AddJsonFile(GeneralConstants.AppSettingsJsonFileName)
                    .Build())
                .AddSingleton<ApplicationSettings>()
                .AddSingleton<IRestClient>((s) => new RestClient(baseUrl 
                ?? s.GetRequiredService<ApplicationSettings>()
                    .BaseUrl))
                .AddSingleton<ICommandDispatcher<char>, MenuCommandDispatcher>()
                .AddSingleton<CategoryDispatcher>()
                .AddSingleton<ProductDispatcher>()
                .AddSingleton<QuitDispatcher>()
                .Scan(sourceSelector => sourceSelector
                    .FromAssemblyOf<Program>()
                    .AddClasses(c => c.Where(type => ServiceConstants
                        .ClientServiceTypes
                            .Any(st => type.Name.EndsWith(st))))
                    .AsMatchingInterface()
                    .WithSingletonLifetime());
        }

        private static void Initialize(
            string baseUrl)
        {
            var servicesCollection = new ServiceCollection();
            
            services = RegisterServices(
                servicesCollection, 
                baseUrl)
                .BuildServiceProvider();
        }

    }
}
