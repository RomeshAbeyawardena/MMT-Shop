using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShop.Client.Base
{
    public class ProviderBase
    {
        public ProviderBase(IRestClient restClient)
        {
            RestClient = restClient;
        }

        protected IRestClient RestClient { get; }
    }
}
