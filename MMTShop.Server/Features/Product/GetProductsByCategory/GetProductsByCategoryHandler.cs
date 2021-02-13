using MediatR;
using MMTShop.Shared.Contracts.Repository;
using MMTShop.Shared.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Product.GetProductsByCategory
{
    public class GetProductsByCategoryHandler
        : IRequestHandler<GetProductsByCategoryRequest, ProductResponse>
    {
        public async Task<ProductResponse> Handle(
            GetProductsByCategoryRequest request, 
            CancellationToken cancellationToken)
        {
            var products = await productRepository
                .GetProductsAsync(
                request.Category, 
                cancellationToken);
            
            return new ProductResponse { Products = products };
        }

        public GetProductsByCategoryHandler(
            IProductRepository productRepository) 
        {
            this.productRepository = productRepository;
        }

        private readonly IProductRepository productRepository;
    }
}
