using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NecroSharper.IdentityServer10.Admin.EntityFramework.Shared.DbContexts;
using NecroSharper.IdentityServer10.STS.Identity.Helpers;

namespace NecroSharper.IdentityServer10.STS.Identity.Configuration.Test;

public class StartupTest
{
    public StartupTest(IWebHostEnvironment environment, IConfiguration configuration)
    {
    }

    public void RegisterDbContexts(IServiceCollection services)
    {
        services.RegisterDbContextsStaging<AdminIdentityDbContext, IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, IdentityServerDataProtectionDbContext>();
    }
}