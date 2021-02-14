using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMTShop.Shared;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts.Modules;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTShop.Client
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            //Set as null to use value in appSettings.json
            Initialize(null);
            
            while(isRunning)
            {
                try
                {
                    Console
                        .WriteLine(
                        "Welcome to MMT Shop.{0}Please select an option{0}", 
                        newLine);

                    DisplayOptions();

                    if(await ParseInput(Console.ReadKey(true).KeyChar))
                    { 
                        WaitForInput();
                    }
                }
                catch(InvalidOperationException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            Console.WriteLine("Good Bye!");
        }

        #region Methods

        #region Setup
        private static IServiceCollection RegisterServices(
            IServiceCollection services,
            string baseUrl)
        {
            return services
                .AddSingleton<IConfiguration>((s) => new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build())
                .AddSingleton<ApplicationSettings>()
                .AddScoped<IRestClient>((s) => new RestClient(baseUrl 
                ?? s.GetRequiredService<ApplicationSettings>()
                    .BaseUrl))
                .Scan(sourceSelector => sourceSelector
                    .FromAssemblyOf<Program>()
                    .AddClasses(c => c.Where(type => ServiceConstants.ClientServiceTypes
                        .Any(st => type.Name.EndsWith(st))))
                    .AsMatchingInterface()
                    .WithScopedLifetime());
        }

        private static void Initialize(
            string baseUrl)
        {
            isRunning = true;
            var servicesCollection = new ServiceCollection();
            
            services = RegisterServices(
                servicesCollection, 
                baseUrl)
                .BuildServiceProvider();

            actionDictionary = new Dictionary<char, Func<Task<bool>>>
            {
                { '1', ProductModule.GetFeaturedProducts },
                { '2', () => CategoryModule.GetCategories(ProductModule.GetProductsByCategory) },
                { 'q', Quit }
            };
        }

        #endregion

        private static void WaitForInput()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
        }
        
        private static Task<bool> Quit()
        {
            isRunning = false;
            return Task.FromResult(false);
        }

        private static void DisplayOptions()
        {
            Console.WriteLine("1. Display featured products{0}" +
                "2. Display categories and get products for a specific category{0}" +
                "q. Quit", newLine);
        }

        private static async Task<bool> ParseInput(
            char input)
        {
            const string InvalidOptionExceptionMessage = "Input must be a number between 1-2 or q to quit";

            if(!actionDictionary.TryGetValue(input, out var action))
            {
                throw new InvalidOperationException(InvalidOptionExceptionMessage);
            }

            return await action.Invoke();
        }

        #endregion
        
        #region Dependency Injected Properties
        static IProductModule ProductModule => services
            .GetRequiredService<IProductModule>();

        static ICategoryModule CategoryModule => services
            .GetRequiredService<ICategoryModule>();
        #endregion

        #region Fields
        static Dictionary<char, Func<Task<bool>>> actionDictionary;
        static bool isRunning = false;
        static readonly string newLine = Environment.NewLine;
        static IServiceProvider services;
        #endregion
    }
}
