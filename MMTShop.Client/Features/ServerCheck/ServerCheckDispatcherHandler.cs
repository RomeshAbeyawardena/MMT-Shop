using MMTShop.Shared;
using MMTShop.Shared.Base;
using MMTShop.Shared.Contracts.Provider;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Client.Features.ServerCheck
{
    public class ServerCheckDispatcherHandler
        : DispatcherHandlerBase<bool>
    {
        public override bool Invoke(
            object state)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> InvokeAsync(
            object state, 
            CancellationToken cancellationToken)
        {
            while (!await serverCheckProvider
                .IsServerLive(cancellationToken))
            {
                var retryInterval = applicationSettings
                    .ClientRetryIntervalInSeconds;

                Thread.Sleep(retryInterval);

                Console.WriteLine("MMT Shop Server unavailable. Retrying in {0} seconds...", 
                    retryInterval);

                return await InvokeAsync(
                    state, 
                    cancellationToken);
            }

            return true;
        }

        public ServerCheckDispatcherHandler(
            ApplicationSettings applicationSettings,
            IServerCheckProvider serverCheckProvider)
        {
            this.applicationSettings = applicationSettings;
            this.serverCheckProvider = serverCheckProvider;
        }

        private readonly ApplicationSettings applicationSettings;
        private readonly IServerCheckProvider serverCheckProvider;
    }
}
