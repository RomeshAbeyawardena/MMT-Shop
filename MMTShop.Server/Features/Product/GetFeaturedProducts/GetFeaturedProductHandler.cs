using Dapper;
using MediatR;
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

namespace MMTShop.Server.Features.Product.GetFeaturedProducts
{
    public class GetFeaturedProductHandler 
        : DbRequestHandlerBase<GetFeaturedProductRequest, GetFeaturedProductResponse>
    {
        public override async Task<GetFeaturedProductResponse> Handle(GetFeaturedProductRequest request, CancellationToken cancellationToken)
        {
            var products = await DbConnection
                .QueryAsync<Shared.Models.Product>(DataAccess
                    .GetCommand(DataConstants.GetFeaturedProducts));

            return new GetFeaturedProductResponse { Products = products };
        }

        public GetFeaturedProductHandler(
            IDbConnection dbConnection,
            IDataAccess dataAccess)
            : base(dbConnection, 
                   dataAccess)
        {
            
        }

    }
}
