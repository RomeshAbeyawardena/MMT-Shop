using MMTShop.Client.Base;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts.Provider;
using MMTShop.Shared.Responses;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Models = MMTShop.Shared.Models;

namespace MMTShop.Client.Features.Product
{
    public class ProductProvider 
        : ProviderBase, IProductProvider
    {
        public async Task<IEnumerable<Models.Product>> GetFeaturedProductsAsync(
            CancellationToken cancellationToken)
        {
            var request = new RestRequest(
                HttpClientConstants.GetProductsUrl);

            var response = await RestClient
                .GetAsync<ProductResponse>(
                    request, 
                    cancellationToken);

            return response.Products;
        }

        public async Task<IEnumerable<Models.Product>> GetProductsByCategoryName(
            string categoryName, 
            CancellationToken cancellationToken)
        {
            var request = new RestRequest(
                $"{HttpClientConstants.GetProductsUrl}/{categoryName}");

            var response = await RestClient
                .GetAsync<ProductResponse>(
                    request, 
                    cancellationToken);

            return response.Products;
        }

        public ProductProvider(
            IRestClient restClient)
            : base(restClient)
        {
        }

    }
}
