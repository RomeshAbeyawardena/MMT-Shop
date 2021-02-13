using Dapper;
using MMTShop.Server.Base;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts;
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
            var categories = await DbConnection
                .QueryAsync<Shared.Models.Category>(DataAccess
                    .GetCommand(DataConstants.GetCategories));

            return new GetCategoriesResponse { Categories = categories };
        }

        public GetCategoriesHandler(
            IDbConnection dbConnection,
            IDataAccess dataAccess)
            : base (dbConnection,
                    dataAccess)
        {
            
        }

    }
}
