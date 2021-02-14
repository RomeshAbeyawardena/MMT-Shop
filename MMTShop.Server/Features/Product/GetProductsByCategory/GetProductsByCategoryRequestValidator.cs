using FluentValidation;
using FluentValidation.Validators;
using MMTShop.Shared.Contracts.Provider;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Product.GetProductsByCategory
{
    public class GetProductsByCategoryRequestValidator 
        : AbstractValidator<GetProductsByCategoryRequest>
    {
        public GetProductsByCategoryRequestValidator(
            ICategoryProvider categoryProvider)
        {
            RuleFor(p => p.Category)
                .NotEmpty()
                .CustomAsync(EnsureCategoryIsValid);
            this.categoryProvider = categoryProvider;
        }

        private async Task EnsureCategoryIsValid(
            string categoryName, 
            CustomContext context, 
            CancellationToken cancellationToken)
        {
            var categories = await categoryProvider.GetCategoriesAsync(cancellationToken);

            if(!categories.Any(c => c.Name
                .Equals(categoryName, StringComparison.InvariantCultureIgnoreCase)))
            {
                context.AddFailure(
                    nameof(categoryName), 
                    "Category not found");
            }
        }

        private readonly ICategoryProvider categoryProvider;
    }
}
