using MediatR;
using MMTShop.Shared.Contracts.Provider;
using MMTShop.Shared.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Category.GetCategories
{
    public class GetCategoriesHandler 
        : IRequestHandler<GetCategoriesRequest, CategoryResponse>
    {
        public async Task<CategoryResponse> Handle(
            GetCategoriesRequest request, 
            CancellationToken cancellationToken)
        {
            var categories = await categoryProvider
                .GetCategories(cancellationToken);

            return new CategoryResponse { Categories = categories };
        }

        public GetCategoriesHandler(
            ICategoryProvider categoryProvider)
        {
            this.categoryProvider = categoryProvider;
        }

        private readonly ICategoryProvider categoryProvider;
    }
}
