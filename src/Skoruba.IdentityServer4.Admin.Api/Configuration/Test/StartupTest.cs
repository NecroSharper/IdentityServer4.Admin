using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Skoruba.IdentityServer4.Admin.Api.Helpers;
using Skoruba.IdentityServer4.Admin.Api.Middlewares;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.DbContexts;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity;

namespace Skoruba.IdentityServer4.Admin.Api.Configuration.Test;

public class StartupTest
{
    public StartupTest(IWebHostEnvironment env, IConfiguration configuration)
    {
        HostingEnvironment = env;
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public IWebHostEnvironment HostingEnvironment { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        var adminApiConfiguration = Configuration.GetSection(nameof(AdminApiConfiguration)).Get<AdminApiConfiguration>();
        services.AddSingleton(adminApiConfiguration);

        RegisterDbContexts(services);
        services.AddDataProtection<IdentityServerDataProtectionDbContext>(Configuration);
        services.AddScoped<ControllerExceptionFilterAttribute>();
        services.AddScoped<IApiErrorResources, ApiErrorResources>();
        RegisterAuthorization(services);

        var profileTypes = new HashSet<Type>
        {
            typeof(IdentityMapperProfile<IdentityRoleDto, IdentityUserRolesDto, string, IdentityUserClaimsDto,
                IdentityUserClaimDto, IdentityUserProviderDto, IdentityUserProvidersDto, IdentityUserChangePasswordDto,
                IdentityRoleClaimDto, IdentityRoleClaimsDto>)
        };

        services.AddAdminAspNetIdentityServices<AdminIdentityDbContext, IdentityServerPersistedGrantDbContext,
            IdentityUserDto, IdentityRoleDto, UserIdentity, UserIdentityRole, string, UserIdentityUserClaim,
            UserIdentityUserRole, UserIdentityUserLogin, UserIdentityRoleClaim, UserIdentityUserToken,
            IdentityUsersDto, IdentityRolesDto, IdentityUserRolesDto, IdentityUserClaimsDto, IdentityUserProviderDto,
            IdentityUserProvidersDto, IdentityUserChangePasswordDto, IdentityRoleClaimsDto, IdentityUserClaimDto,
            IdentityRoleClaimDto>(profileTypes);

        RegisterAuthentication(services);
        services.AddAdminServices<IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, AdminLogDbContext>();
        services.AddMvcServices<IdentityUserDto, IdentityRoleDto, UserIdentity, UserIdentityRole, string,
            UserIdentityUserClaim, UserIdentityUserRole, UserIdentityUserLogin, UserIdentityRoleClaim,
            UserIdentityUserToken, IdentityUsersDto, IdentityRolesDto, IdentityUserRolesDto,
            IdentityUserClaimsDto, IdentityUserProviderDto, IdentityUserProvidersDto, IdentityUserChangePasswordDto,
            IdentityRoleClaimsDto, IdentityUserClaimDto, IdentityRoleClaimDto>();
        services.AddAuditEventLogging<AdminAuditLogDbContext, AuditLog>(Configuration);
    }

    public void RegisterDbContexts(IServiceCollection services)
    {
        services.RegisterDbContextsStaging<AdminIdentityDbContext, IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, AdminLogDbContext, AdminAuditLogDbContext, IdentityServerDataProtectionDbContext>();
    }

    public void RegisterAuthentication(IServiceCollection services)
    {
        services
            .AddIdentity<UserIdentity, UserIdentityRole>(options => Configuration.GetSection(nameof(IdentityOptions)).Bind(options))
            .AddEntityFrameworkStores<AdminIdentityDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultForbidScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public void RegisterAuthorization(IServiceCollection services)
    {
        services.AddAuthorizationPolicies();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment _, ILoggerFactory _1)
    {
        app.UseRouting();
        app.UseAuthentication();
        app.UseMiddleware<AuthenticatedTestRequestMiddleware>();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    public void UseAuthentication(IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseMiddleware<AuthenticatedTestRequestMiddleware>();
    }
}