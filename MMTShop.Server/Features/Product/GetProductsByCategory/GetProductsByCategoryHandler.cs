using Dapper;
using MMTShop.Server.Base;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Product.GetProductsByCategory
{
    public class GetProductsByCategoryHandler
        : DbRequestHandlerBase<GetProductsByCategoryRequest, GetProductsByCategoryResponse>
    {
        public override async Task<GetProductsByCategoryResponse> Handle(GetProductsByCategoryRequest request, CancellationToken cancellationToken)
        {
            var products = await DbConnection
                .QueryAsync<Shared.Models.Product>(DataAccess
                    .GetCommand(DataConstants.GetFeaturedProducts));

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
