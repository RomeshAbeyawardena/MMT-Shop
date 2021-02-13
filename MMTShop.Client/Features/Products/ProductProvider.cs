using MMTShop.Client.Base;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts.Provider;
using MMTShop.Shared.Models;
using MMTShop.Shared.Responses;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Client.Features.Products
{
    public class ProductProvider : ProviderBase, IProductProvider
    {
        public async Task<IEnumerable<Product>> GetFeaturedProductsAsync(
            CancellationToken cancellationToken)
        {
            var request = new RestRequest(
                HttpClientConstants.GetProductsUrl);

            var response = await RestClient
                .GetAsync<ProductResponse>(request, cancellationToken);

            return response.Products;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryName(
            string categoryName, 
            CancellationToken cancellationToken)
        {
            var request = new RestRequest(
                $"{HttpClientConstants.GetProductsUrl}/{categoryName}");

            var response = await RestClient
                .GetAsync<ProductResponse>(request, cancellationToken);

            return response.Products;
        }

        public ProductProvider(IRestClient restClient)
            : base(restClient)
        {
        }

    }
}
