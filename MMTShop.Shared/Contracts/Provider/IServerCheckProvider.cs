using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts.Provider
{
    public interface IServerCheckProvider
    {
        Task<bool> IsServerLive(
            CancellationToken cancellationToken);
    }
}
