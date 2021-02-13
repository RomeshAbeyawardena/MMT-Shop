using MediatR;
using MMTShop.Shared.Responses;

namespace MMTShop.Server.Features.Product.GetFeaturedProducts
{
    public class GetFeaturedProductsRequest 
        : IRequest<ProductResponse>
    {
        
    }
}
