using Microsoft.Extensions.DependencyInjection;
using MMTShop.Client.Features.Products;
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
        public Program()
        {
            isRunning = true;
            var servicesCollection = new ServiceCollection();
            actionDictionary = new Dictionary<int, Func<Task>>();
            
            services = servicesCollection
                .AddScoped<IRestClient, RestClient>()
                .AddScoped<IProductProvider, ProductProvider>()
                .BuildServiceProvider();

            actionDictionary.Add(1, GetFeaturedProducts);
        }

        private async Task GetFeaturedProducts()
        {
            var productProvider = services
                .GetRequiredService<IProductProvider>();

            var products = await productProvider
                .GetFeaturedProductsAsync(CancellationToken.None);

            DisplayProducts(products);
        }

        private void DisplayProducts(IEnumerable<Product> products)
        {
            var productCount = products.Count();
            for(var productIndex = 0; productIndex < productCount; productIndex++)
            {
                var product = products
                    .ElementAt(productIndex);
                Console.WriteLine("--- Product {0} of {1}---{2}{2}", 
                    productIndex, 
                    productCount,
                    newLine);

                Console.WriteLine("\tSku: {1}{0}" +
                    "\tName: {2}{0}" +
                    "\tDescription: {3}{0}" +
                    "\tPrice: {4:c:0}{0}{0}",
                    newLine,
                    product.Sku,
                    product.Name,
                    product.Description,
                    product.Price);

                Console.WriteLine("-------------------------------");
            }
        }

        static async Task Main(string[] args)
        {
            while(isRunning)
            {
                Console
                    .WriteLine("Welcome to MMT Shop.{0}Please select an option{0}", newLine);
                DisplayOptions();
                await ParseInput(Console.ReadLine());
            }

            Console.WriteLine("GoodBye!");
        }

        static void DisplayOptions()
        {
            Console.WriteLine("1. Display featured products{0}" +
                "2. Display categories{0}" +
                "3. Display products of a specific category{0}" +
                "q. Quit", newLine);
        }

        static async Task ParseInput(string input)
        {
            const string InvalidOptionExceptionMessage = "Input must be a number between 1-3 or q to quit";
            if (string.IsNullOrEmpty(input))
            {
                throw new InvalidOperationException("Input required");
            }

            if(input.Equals("q", 
                    StringComparison.InvariantCultureIgnoreCase))
            {
                isRunning = false;
            }

            if(!int.TryParse(input, out var result))
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

        static Dictionary<int, Func<Task>> actionDictionary;
        
        static bool isRunning = false;
        static readonly string newLine = Environment.NewLine;
        private IServiceProvider services;
    }
}
