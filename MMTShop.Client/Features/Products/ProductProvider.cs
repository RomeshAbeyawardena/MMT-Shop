using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts.Provider;
using MMTShop.Shared.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Client.Features.Products
{
    public class ProductProvider : IProductProvider
    {
        public async Task<IEnumerable<Product>> GetFeaturedProductsAsync(CancellationToken cancellationToken)
        {
            var request = new RestRequest(
                HttpClientConstants.GetProductsUrl);

            var response = await restClient
                .GetAsync<List<Product>>(request, cancellationToken);

            return response.ToArray();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryName(string categoryName, CancellationToken cancellationToken)
        {
            var request = new RestRequest(
                $"{HttpClientConstants.GetProductsUrl}/{categoryName}");

            var response = await restClient
                .GetAsync<List<Product>>(request, cancellationToken);

            return response;
        }

        public ProductProvider(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        private readonly IRestClient restClient;
    }
}
