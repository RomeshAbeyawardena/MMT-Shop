using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMTShop.Shared;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts;
using MMTShop.Shared.Contracts.Services;
using MMTShop.Shared.Services;
using RestSharp;
using System.Linq;

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
                .AddSingleton<ICategoryService, CategoryService>()
                .AddSingleton<ICommandDispatcher<char>, MenuCommandDispatcher>()
                .Scan(sourceSelector => sourceSelector
                    .FromAssemblyOf<Program>()
                    .AddClasses(c => c.Where(type => type.Name
                        .EndsWith(ServiceConstants
                            .DispatcherHandler)))
                    .AsSelf()
                    .WithSingletonLifetime())
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
