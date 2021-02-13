using Dapper;
using MMTShop.Server.Base;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts;
using MMTShop.Shared.Responses;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Product.GetFeaturedProducts
{
    public class GetFeaturedProductsHandler 
        : DbRequestHandlerBase<GetFeaturedProductsRequest, ProductResponse>
    {
        public override async Task<ProductResponse> Handle(
            GetFeaturedProductsRequest request, 
            CancellationToken cancellationToken)
        {
            var products = await DbConnection
                .QueryAsync<Shared.Models.Product>(DataAccess
                    .GetCommand(DataConstants.GetFeaturedProducts));

            return new ProductResponse { Products = products };
        }

        public GetFeaturedProductsHandler(
            IDbConnection dbConnection,
            IDatabaseQueryProvider dataAccess)
            : base(dbConnection, 
                   dataAccess)
        {
            
        }

    }
}
