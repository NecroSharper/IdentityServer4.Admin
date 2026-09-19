using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Skoruba.IdentityServer4.Admin.Api.Configuration.Test;

namespace Skoruba.IdentityServer4.Admin.Api.IntegrationTests.Tests.Base
{
    public class TestFixture : IDisposable
    {
        public TestServer TestServer;

        public HttpClient Client { get; }

        private readonly IHost _host;

        public TestFixture()
        {
            _host = new HostBuilder()
                .ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    configApp.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    configApp.AddJsonFile("serilog.json", optional: true, reloadOnChange: true);

                    var env = hostContext.HostingEnvironment;

                    configApp.AddJsonFile($"serilog.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    configApp.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                })
                .ConfigureWebHostDefaults(webBuilder => webBuilder
                    .UseTestServer()
                    .UseStartup<StartupTest>())
                .Start();

            TestServer = _host.GetTestServer();
            Client = TestServer.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            _host.Dispose();
        }
    }
}