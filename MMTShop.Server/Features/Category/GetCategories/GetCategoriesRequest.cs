using MediatR;
using MMTShop.Shared.Responses;

namespace MMTShop.Server.Features.Category.GetCategories
{
    public class GetCategoriesRequest 
        : IRequest<CategoryResponse>
    {
        
    }
}
