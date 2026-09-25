using NecroSharper.IdentityServer10.Shared.Configuration.Configuration.Identity;
using NecroSharperIdentityServer10Admin.STS.Identity.Configuration.Interfaces;

namespace NecroSharperIdentityServer10Admin.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}







