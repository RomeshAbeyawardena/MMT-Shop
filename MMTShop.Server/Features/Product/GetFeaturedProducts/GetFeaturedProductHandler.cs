using Dapper;
using MediatR;
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
    public class GetFeaturedProductHandler : IRequestHandler<GetFeaturedProductRequest, GetFeaturedProductResponse>
    {
        public async Task<GetFeaturedProductResponse> Handle(GetFeaturedProductRequest request, CancellationToken cancellationToken)
        {
            var products = await dbConnection.QueryAsync<Shared.Models.Product>(dataAccess
                .GetCommand(DataConstants.GetFeaturedProducts));

            return new GetFeaturedProductResponse { Products = products };
        }

        public GetFeaturedProductHandler(IDbConnection dbConnection,
            IDataAccess dataAccess)
        {
            this.dbConnection = dbConnection;
            this.dataAccess = dataAccess;
        }

        private readonly IDbConnection dbConnection;
        private readonly IDataAccess dataAccess;
    }
}
