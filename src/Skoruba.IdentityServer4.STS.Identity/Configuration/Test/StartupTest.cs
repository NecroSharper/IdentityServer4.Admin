using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.DbContexts;
using Skoruba.IdentityServer4.STS.Identity.Helpers;

namespace Skoruba.IdentityServer4.STS.Identity.Configuration.Test;

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