using MMTShop.Server.Base;
using MMTShop.Shared.Contracts;
using MMTShop.Shared.Contracts.Provider;
using MMTShop.Shared.Responses;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Category.GetCategories
{
    public class GetCategoriesHandler 
        : DbRequestHandlerBase<GetCategoriesRequest, CategoryResponse>
    {
        public override async Task<CategoryResponse> Handle(
            GetCategoriesRequest request, 
            CancellationToken cancellationToken)
        {
            var categories = await categoryProvider
                .GetCategories(cancellationToken);

            return new CategoryResponse { Categories = categories };
        }

        public GetCategoriesHandler(
            IDbConnection dbConnection,
            IDatabaseQueryProvider dataAccess,
            ICategoryProvider categoryProvider)
            : base (dbConnection,
                    dataAccess)
        {
            this.categoryProvider = categoryProvider;
        }

        private readonly ICategoryProvider categoryProvider;
    }
}
