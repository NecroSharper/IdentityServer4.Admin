using NecroSharper.IdentityServer10.Shared.Configuration.Configuration.Identity;
using NecroSharper.IdentityServer10.STS.Identity.Configuration.Interfaces;

namespace NecroSharper.IdentityServer10.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}