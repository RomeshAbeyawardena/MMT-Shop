using RestSharp;

namespace MMTShop.Client.Base
{
    public class ProviderBase
    {
        public ProviderBase(
            IRestClient restClient)
        {
            RestClient = restClient;
        }

        protected IRestClient RestClient { get; }
    }
}
