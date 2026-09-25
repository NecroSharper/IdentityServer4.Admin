using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NecroSharperIdentityServer10Admin.Admin.EntityFramework.Shared.DbContexts;
using NecroSharperIdentityServer10Admin.STS.Identity.Helpers;

namespace NecroSharperIdentityServer10Admin.STS.Identity.Configuration.Test;

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







