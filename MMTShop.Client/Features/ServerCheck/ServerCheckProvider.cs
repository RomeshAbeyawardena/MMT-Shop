using MMTShop.Client.Base;
using MMTShop.Shared.Contracts.Provider;
using RestSharp;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Client.Features.ServerCheck
{
    public class ServerCheckProvider : ProviderBase, IServerCheckProvider
    {
        public async Task<bool> IsServerLive(
            CancellationToken cancellationToken)
        {
            var request = new RestRequest();
            var response = await RestClient
                .ExecuteGetAsync(
                    request, 
                    cancellationToken);

            return response
                .IsSuccessful;
        }

        public ServerCheckProvider(
            IRestClient restClient) 
            : base(restClient)
        {
        }
    }
}
