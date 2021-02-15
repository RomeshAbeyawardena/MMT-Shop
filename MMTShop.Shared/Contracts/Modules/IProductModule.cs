using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts.Modules
{
    public interface IProductModule
    {
        Task<bool> DisplayFeaturedProductsAsync(
            CancellationToken cancellationToken);

        Task<bool> DisplayProductsByCategoryAsync(
            string categoryName,
            CancellationToken cancellationToken);
    }
}
