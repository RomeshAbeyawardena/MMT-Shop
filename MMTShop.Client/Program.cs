using Microsoft.Extensions.DependencyInjection;
using MMTShop.Client.Features.Categories;
using MMTShop.Client.Features.Products;
using MMTShop.Shared.Constants;
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

            Initialize(HttpClientConstants.BaseUrl);
            
            while(isRunning)
            {
                Console
                    .WriteLine(
                    "Welcome to MMT Shop.{0}Please select an option{0}", 
                    newLine);

                DisplayOptions();
                await ParseInput(Console.ReadKey(true).KeyChar);
            }

            Console.WriteLine("GoodBye!");
        }

        #region Local Methods
        private static void Initialize(string baseUrl)
        {
            isRunning = true;
            var servicesCollection = new ServiceCollection();
            actionDictionary = new Dictionary<int, Func<Task>>();
            
            services = servicesCollection
                .AddScoped<IRestClient>((s) => new RestClient(baseUrl))
                .AddScoped<IProductProvider, ProductProvider>()
                .AddScoped<ICategoryProvider, CategoryProvider>()
                .BuildServiceProvider();

            actionDictionary.Add(1, GetFeaturedProducts);
            actionDictionary.Add(2, GetCategories);
        }

        private static async Task GetCategories()
        {
            var categoryProvider = services
                .GetRequiredService<ICategoryProvider>();

            var categories = await categoryProvider
                .GetCategories(CancellationToken.None);

            DisplayCategories(categories);
        }

        private static async Task GetFeaturedProducts()
        {
            var productProvider = services
                .GetRequiredService<IProductProvider>();

            var products = await productProvider
                .GetFeaturedProductsAsync(CancellationToken.None);

            DisplayProducts(products);
        }

        private static void DisplayOptions()
        {
            Console.WriteLine("1. Display featured products{0}" +
                "2. Display categories{0}" +
                "3. Display products of a specific category{0}" +
                "q. Quit", newLine);
        }

        private static async Task ParseInput(char input)
        {
            var strInput = input.ToString();

            const string InvalidOptionExceptionMessage = "Input must be a number between 1-3 or q to quit";
            if (string.IsNullOrEmpty(strInput))
            {
                throw new InvalidOperationException("Input required");
            }

            if(strInput.Equals("q", 
                    StringComparison.InvariantCultureIgnoreCase))
            {
                isRunning = false;
                return;
            }

            if(!int.TryParse(strInput, out var result))
            {
                throw new InvalidOperationException(InvalidOptionExceptionMessage);
            }

            actionDictionary.TryGetValue(result, out var action);

            if(action == null)
            {
                throw new InvalidOperationException(InvalidOptionExceptionMessage);
            }

            await action.Invoke();
        }

        private static void DisplayProducts(IEnumerable<Product> products)
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
        
        private static void DisplayCategories(IEnumerable<Category> categories)
        {
            Display(categories, "Category", product => 
                string.Format("\tName: {0}{1}", 
                    product.Name, 
                    newLine));
        }

        private static void Display<T>(IEnumerable<T> items, string itemType, Func<T, string> itemDisplayFormat, params object[] args)
        {
            var productCount = items.Count();
            for(var productIndex = 0; productIndex < productCount; productIndex++)
            {
                var item = items
                    .ElementAt(productIndex);
                Console.WriteLine("--- {0} {1} of {2}---{3}{3}",
                    itemType,
                    productIndex + 1, 
                    productCount,
                    newLine);

                Console.WriteLine(
                    itemDisplayFormat(item));

                Console.WriteLine("------------------------------- {0}", newLine);
            }
        }
        #endregion

        #region Fields
        static Dictionary<int, Func<Task>> actionDictionary;
        static bool isRunning = false;
        static readonly string newLine = Environment.NewLine;
        static IServiceProvider services;
        #endregion
    }
}
