using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NecroSharper.IdentityServer10.STS.Identity.Configuration.Test;

namespace NecroSharper.IdentityServer10.STS.Identity.IntegrationTests.Tests.Base
{
    public class TestFixture : IDisposable
    {
        public TestServer TestServer;
        public HttpClient Client { get; }
        private IHost _host;

        public TestFixture()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((hostContext, configApp) =>
                    {
                        configApp.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                        configApp.AddJsonFile("serilog.json", optional: true, reloadOnChange: true);

                        var env = hostContext.HostingEnvironment;

                        configApp.AddJsonFile($"serilog.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                        configApp.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    });

                    webBuilder.UseStartup<StartupTest>();
                });

            _host = builder.Build();
            _host.StartAsync().GetAwaiter().GetResult();

            TestServer = _host.GetTestServer();
            Client = TestServer.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            TestServer.Dispose();
            _host?.StopAsync().GetAwaiter().GetResult();
            _host?.Dispose();
        }
    }
}