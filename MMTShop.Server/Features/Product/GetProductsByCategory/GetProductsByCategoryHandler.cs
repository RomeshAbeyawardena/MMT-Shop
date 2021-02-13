using Dapper;
using MMTShop.Server.Base;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Product.GetProductsByCategory
{
    public class GetProductsByCategoryHandler
        : DbRequestHandlerBase<GetProductsByCategoryRequest, GetProductsByCategoryResponse>
    {
        public override async Task<GetProductsByCategoryResponse> Handle(
            GetProductsByCategoryRequest request, 
            CancellationToken cancellationToken)
        {
            var products = await DbConnection
                .QueryAsync<Shared.Models.Product>(DataAccess
                    .GetCommand(DataConstants.GetProductsByCategoryName, 
                        new { categoryName = request.Category }));
            
            return new GetProductsByCategoryResponse { Products = products };
        }

        public GetProductsByCategoryHandler(
            IDbConnection dbConnection, 
            IDataAccess dataAccess) 
            : base(dbConnection, 
                   dataAccess)
        {
        }

    }
}
