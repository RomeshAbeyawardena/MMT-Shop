using MMTShop.Client.Base;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts.Provider;
using MMTShop.Shared.Models;
using MMTShop.Shared.Responses;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Client.Features.Categories
{
    public class CategoryProvider : ProviderBase, ICategoryProvider
    {
        public async Task<IEnumerable<Category>> GetCategories(
            CancellationToken cancellationToken)
        {
            var request = new RestRequest(
                HttpClientConstants.GetCategories);

            var response = await RestClient
                .GetAsync<CategoryResponse>(request, cancellationToken);

            return response.Categories;
        }

        public CategoryProvider(IRestClient restClient) 
            : base(restClient)
        {
        }

    }
}
