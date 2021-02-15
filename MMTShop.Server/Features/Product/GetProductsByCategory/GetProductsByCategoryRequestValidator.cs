using FluentValidation;
using FluentValidation.Validators;
using MMTShop.Shared.Contracts.Provider;
using MMTShop.Shared.Contracts.Services;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Product.GetProductsByCategory
{
    public class GetProductsByCategoryRequestValidator 
        : AbstractValidator<GetProductsByCategoryRequest>
    {
        public GetProductsByCategoryRequestValidator(
            ICategoryProvider categoryProvider,
            ICategoryService categoryService)
        {
            RuleFor(p => p.Category)
                .NotEmpty()
                .CustomAsync(EnsureCategoryIsValid);
            this.categoryProvider = categoryProvider;
            this.categoryService = categoryService;
        }

        private async Task EnsureCategoryIsValid(
            string categoryName, 
            CustomContext context, 
            CancellationToken cancellationToken)
        {
            var categories = await categoryProvider.GetCategoriesAsync(cancellationToken);

            var category = categoryService
                .GetCategory(categories, categoryName);

            if(category == null)
            {
                context.AddFailure(
                    nameof(categoryName), 
                    "Category not found");
            }
        }

        private readonly ICategoryProvider categoryProvider;
        private readonly ICategoryService categoryService;
    }
}
