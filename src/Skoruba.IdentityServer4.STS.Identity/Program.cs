using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Skoruba.IdentityServer4.Shared.Configuration.Helpers;
using Skoruba.IdentityServer4.STS.Identity;
using System;
using System.Configuration;
using System.IO;

//namespace Skoruba.IdentityServer4.STS.Identity;

var builder = WebApplication.CreateBuilder();

#region Config

builder.Configuration.AddJsonFile("appsettings.json", true, true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);
builder.Configuration.AddJsonFile("serilog.json", true, true);
builder.Configuration.AddJsonFile($"serilog.{builder.Environment.EnvironmentName}.json", true, true);

if (builder.Environment.IsDevelopment())
    builder.Configuration.AddUserSecrets<Program>();

builder.WebHost.ConfigureKestrel(options => { options.AddServerHeader = false; });

#endregion

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

try
{
    DockerHelpers.ApplyDockerConfiguration(builder.Configuration);

    builder.Configuration.AddAzureKeyVaultConfiguration(builder.Configuration);
    builder.Configuration.AddEnvironmentVariables();
    builder.Configuration.AddCommandLine(args);

    #region Configuration

    IRootConfiguration rootConfiguration = new RootConfiguration();
    builder.Configuration.GetSection(ConfigurationConsts.AdminConfigurationKey).Bind(rootConfiguration.AdminConfiguration);
    builder.Configuration.GetSection(ConfigurationConsts.RegisterConfigurationKey).Bind(rootConfiguration.RegisterConfiguration);
    builder.Services.AddSingleton(rootConfiguration);

    #endregion

    #region Services

    // Register DbContexts for IdentityServer and Identity
    builder.Services.RegisterDbContexts<AdminIdentityDbContext, IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, IdentityServerDataProtectionDbContext>(builder.Configuration);

    // Save data protection keys to db, using a common application name shared between Admin and STS
    builder.Services.AddDataProtection<IdentityServerDataProtectionDbContext>(builder.Configuration);

    // Add email senders which is currently setup for SendGrid and SMTP
    builder.Services.AddEmailSenders(builder.Configuration);

    // Add services for authentication, including Identity model and external providers
    builder.Services.AddAuthenticationServices<AdminIdentityDbContext, UserIdentity, UserIdentityRole>(builder.Configuration);
    builder.Services.AddIdentityServer<IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, UserIdentity>(builder.Configuration);

    // Add HSTS options
    builder.Services.AddHsts(options =>
    {
        options.Preload = true;
        options.IncludeSubDomains = true;
        options.MaxAge = TimeSpan.FromDays(365);
    });

    // Add all dependencies for Asp.Net Core Identity in MVC - these dependencies are injected into generic Controllers
    // Including settings for MVC and Localization
    // If you want to change primary keys or use another db model for Asp.Net Core Identity:
    builder.Services.AddMvcWithLocalization<UserIdentity, string>(builder.Configuration);

    // Add authorization policies for MVC
    builder.Services.AddAuthorizationPolicies(rootConfiguration);

    builder.Services.AddIdSHealthChecks<IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, AdminIdentityDbContext, IdentityServerDataProtectionDbContext>(builder.Configuration);

    #endregion

    #region Serilog

    builder.Services.AddSerilog((_, loggerConfig) => loggerConfig
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.WithProperty("ApplicationName", builder.Environment.ApplicationName));
    builder.Host.UseSerilog();

    #endregion

    var app = builder.Build();

    app.UseCookiePolicy();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseHsts();
    }

    app.UsePathBase(builder.Configuration.GetValue<string>("BasePath"));

    app.UseStaticFiles();

    //https://github.com/DuendeArchive/IdentityServer4/issues/324
    var fordwardedHeaderOptions = new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    };
    fordwardedHeaderOptions.KnownIPNetworks.Clear();
    fordwardedHeaderOptions.KnownProxies.Clear();

    app.UseForwardedHeaders(fordwardedHeaderOptions);
    app.UseIdentityServer();

    // Add custom security headers
    app.UseSecurityHeaders(builder.Configuration);

    app.UseMvcLocalizationServices();

    app.UseRouting();
    app.UseAuthorization();

    app.MapDefaultControllerRoute();
    app.MapHealthChecks("/health", new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

    //https://github.com/skoruba/IdentityServer4.Admin/issues/996
    //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    await Log.CloseAndFlushAsync();
}