using NecroSharper.IdentityServer10.Shared.Configuration.Configuration.Identity;

namespace NecroSharper.IdentityServer10.STS.Identity.Configuration.Interfaces
{
    public interface IRootConfiguration
    {
        AdminConfiguration AdminConfiguration { get; }

        RegisterConfiguration RegisterConfiguration { get; }
    }
}