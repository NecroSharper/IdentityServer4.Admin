using NecroSharper.IdentityServer10.Shared.Configuration.Configuration.Identity;

namespace NecroSharperIdentityServer10Admin.STS.Identity.Configuration.Interfaces
{
    public interface IRootConfiguration
    {
        AdminConfiguration AdminConfiguration { get; }

        RegisterConfiguration RegisterConfiguration { get; }
    }
}







