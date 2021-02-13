using Microsoft.Extensions.Configuration;
using System;

namespace MMTShop.Shared
{
    public sealed class ApplicationSettings
    {
        public ApplicationSettings(IConfiguration configuration)
        {
            DefaultConnectionString = configuration.GetConnectionString("default");
            configuration.Bind(this);
        }

        public string DefaultConnectionString { get; set; }
    }
}
