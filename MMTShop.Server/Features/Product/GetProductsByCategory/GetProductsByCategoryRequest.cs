using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MMTShop.Server.Features.Product.GetProductsByCategory
{
    public class GetProductsByCategoryRequest : IRequest<GetProductsByCategoryResponse>
    {
        [Required]
        public string Category { get; set; }
    }
}
