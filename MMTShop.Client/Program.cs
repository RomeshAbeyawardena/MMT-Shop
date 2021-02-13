using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMTShop.Shared;
using MMTShop.Shared.Contracts.Provider;
using MMTShop.Shared.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Client
{
    class Program
    {
        
        private static async Task Main(string[] args)
        {
            //this could be further enhanced so the base url could come from 
            //an app settings file instead of a constant.

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
                    .AddClasses(c => c.Where(type => type.Name.EndsWith("Provider")))
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
                { '1', GetFeaturedProducts },
                { '2', GetCategories },
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

        private static async Task<bool> GetFeaturedProducts()
        {
            var products = await ProductProvider
                .GetFeaturedProductsAsync(CancellationToken.None);

            DisplayProducts(products);
            return true;
        }

        private static async Task<bool> GetCategories()
        {
            var categoryProvider = services
                .GetRequiredService<ICategoryProvider>();

            var categories = await categoryProvider
                .GetCategories(CancellationToken.None);

            DisplayCategories(categories);
            Console.WriteLine("Enter the category you wish to view products for:");

            var categoryName = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(categoryName))
            { 
                if(categories
                    .Any(category => category.Name.Equals(categoryName, 
                        StringComparison.InvariantCultureIgnoreCase)))
                { 
                    await GetProductsByCategory(categoryName);
                    return true;
                }

                Console.WriteLine("Invalid category selected");
            }

            Console.WriteLine("No category selected");

            return true;
        }

        private static async Task GetProductsByCategory(
            string categoryName)
        {
            var products = await ProductProvider
                .GetProductsByCategoryName(
                    categoryName,
                    CancellationToken.None);

            DisplayProducts(products);
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

        private static void DisplayProducts(
            IEnumerable<Product> products)
        {
            Display(products, "Product", product => 
                string.Format("\tSku: {0}{4}" +
                    "\tName: {1}{4}" +
                    "\tDescription: {2}{4}" +
                    "\tPrice: {3:c2}{4}",
                    product.Sku,
                    product.Name,
                    product.Description,
                    product.Price,
                    newLine));
        }
        
        private static void DisplayCategories(
            IEnumerable<Category> categories)
        {
            Display(categories, "Category", product => 
                string.Format("\tName: {0}{1}", 
                    product.Name, 
                    newLine));
        }

        private static void Display<T>(
            IEnumerable<T> items, 
            string itemType, 
            Func<T, string> itemDisplayFormat)
        {
            var productCount = items.Count();
            for(var productIndex = 0; productIndex < productCount; productIndex++)
            {
                var item = items
                    .ElementAt(productIndex);
                Console.WriteLine("--- {0} {1} of {2} ---{3}{3}",
                    itemType,
                    productIndex + 1, 
                    productCount,
                    newLine);

                Console.WriteLine(
                    itemDisplayFormat(item));

                Console.WriteLine("-------------------------------{0}", newLine);
            }
        }
        #endregion

        #region Properties
        public static IProductProvider ProductProvider => services
                .GetRequiredService<IProductProvider>();
        #endregion

        #region Fields
        static Dictionary<char, Func<Task<bool>>> actionDictionary;
        static bool isRunning = false;
        static readonly string newLine = Environment.NewLine;
        static IServiceProvider services;
        #endregion
    }
}
