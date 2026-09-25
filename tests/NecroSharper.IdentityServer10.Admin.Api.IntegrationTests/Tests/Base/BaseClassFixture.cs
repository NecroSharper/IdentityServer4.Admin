using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NecroSharper.IdentityServer10.Admin.Api.Configuration;
using NecroSharper.IdentityServer10.Admin.Api.Configuration.Test;
using NecroSharper.IdentityServer10.Admin.Api.IntegrationTests.Common;
using Xunit;

namespace NecroSharper.IdentityServer10.Admin.Api.IntegrationTests.Tests.Base
{
    public class BaseClassFixture : IClassFixture<TestFixture>
    {
        protected readonly HttpClient Client;
        protected readonly TestServer TestServer;

        public BaseClassFixture(TestFixture fixture)
        {
            Client = fixture.Client;
            TestServer = fixture.TestServer;
        }

        protected virtual void SetupAdminClaimsViaHeaders()
        {
            using (var scope = TestServer.Services.CreateScope())
            {
                var configuration = scope.ServiceProvider.GetRequiredService<AdminApiConfiguration>();
                Client.SetAdminClaimsViaHeaders(configuration);
            }
        }
    }
}