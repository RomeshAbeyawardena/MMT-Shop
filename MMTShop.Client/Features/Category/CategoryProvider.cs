using MMTShop.Client.Base;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts.Provider;
using MMTShop.Shared.Responses;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Models = MMTShop.Shared.Models;

namespace MMTShop.Client.Features.Category
{
    public class CategoryProvider : ProviderBase, ICategoryProvider
    {
        public async Task<IEnumerable<Models.Category>> GetCategories(
            CancellationToken cancellationToken)
        {
            var request = new RestRequest(
                HttpClientConstants.GetCategories);

            var response = await RestClient
                .GetAsync<CategoryResponse>(
                    request, 
                    cancellationToken);

            return response.Categories;
        }

        public CategoryProvider(IRestClient restClient) 
            : base(restClient)
        {
        }

    }
}
