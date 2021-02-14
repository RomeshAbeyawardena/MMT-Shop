using MediatR;
using Microsoft.AspNetCore.Authentication;
using MMTShop.Shared.Contracts.Repository;
using MMTShop.Shared.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Product.GetFeaturedProducts
{
    public class GetFeaturedProductsHandler 
        : IRequestHandler<GetFeaturedProductsRequest, ProductResponse>
    {
        public async Task<ProductResponse> Handle(
            GetFeaturedProductsRequest request, 
            CancellationToken cancellationToken)
        {
            var timeNow = systemClock.UtcNow;
            var products = await productRepository
                .GetFeaturedProductsAsync(
                    timeNow.DateTime, 
                    timeNow.DateTime, 
                    cancellationToken);

            return new ProductResponse { Products = products };
        }

        public GetFeaturedProductsHandler(
            IProductRepository productRepository,
            ISystemClock systemClock)
        {
            this.productRepository = productRepository;
            this.systemClock = systemClock;
        }

        private readonly IProductRepository productRepository;
        private readonly ISystemClock systemClock;
    }
}
