using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts.Modules
{
    public interface IProductModule
    {
        Task<bool> DisplayFeaturedProducts(
            CancellationToken cancellationToken);

        Task<bool> DisplayProductsByCategory(
            string categoryName,
            CancellationToken cancellationToken);
    }
}
