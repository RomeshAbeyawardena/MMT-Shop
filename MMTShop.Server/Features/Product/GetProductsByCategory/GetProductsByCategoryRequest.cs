using MediatR;
using MMTShop.Shared.Responses;
using System.ComponentModel.DataAnnotations;

namespace MMTShop.Server.Features.Product.GetProductsByCategory
{
    public class GetProductsByCategoryRequest : IRequest<ProductResponse>
    {
        [Required]
        public string Category { get; set; }
    }
}
