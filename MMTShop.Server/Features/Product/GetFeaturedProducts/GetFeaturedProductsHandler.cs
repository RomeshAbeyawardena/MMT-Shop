using Dapper;
using MMTShop.Server.Base;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Product.GetFeaturedProducts
{
    public class GetFeaturedProductsHandler 
        : DbRequestHandlerBase<GetFeaturedProductsRequest, GetFeaturedProductsResponse>
    {
        public override async Task<GetFeaturedProductsResponse> Handle(
            GetFeaturedProductsRequest request, 
            CancellationToken cancellationToken)
        {
            var products = await DbConnection
                .QueryAsync<Shared.Models.Product>(DataAccess
                    .GetCommand(DataConstants.GetFeaturedProducts));

            return new GetFeaturedProductsResponse { Products = products };
        }

        public GetFeaturedProductsHandler(
            IDbConnection dbConnection,
            IDataAccess dataAccess)
            : base(dbConnection, 
                   dataAccess)
        {
            
        }

    }
}
