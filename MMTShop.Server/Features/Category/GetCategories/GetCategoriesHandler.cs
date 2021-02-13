using Dapper;
using MMTShop.Server.Base;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts;
using MMTShop.Shared.Contracts.Provider;
using MMTShop.Shared.Models;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Category.GetCategories
{
    public class GetCategoriesHandler 
        : DbRequestHandlerBase<GetCategoriesRequest, GetCategoriesResponse>
    {
        public override async Task<GetCategoriesResponse> Handle(
            GetCategoriesRequest request, 
            CancellationToken cancellationToken)
        {
            var categories = await categoryProvider
                .GetCategories(cancellationToken);

            return new GetCategoriesResponse { Categories = categories };
        }

        public GetCategoriesHandler(
            IDbConnection dbConnection,
            IDataAccess dataAccess,
            ICategoryProvider categoryProvider)
            : base (dbConnection,
                    dataAccess)
        {
            this.categoryProvider = categoryProvider;
        }

        private readonly ICategoryProvider categoryProvider;
    }
}
