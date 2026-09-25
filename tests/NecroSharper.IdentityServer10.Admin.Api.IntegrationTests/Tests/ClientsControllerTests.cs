using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using NecroSharper.IdentityServer10.Admin.Api.Configuration.Test;
using NecroSharper.IdentityServer10.Admin.Api.IntegrationTests.Common;
using NecroSharper.IdentityServer10.Admin.Api.IntegrationTests.Tests.Base;
using Xunit;

namespace NecroSharper.IdentityServer10.Admin.Api.IntegrationTests.Tests
{
    public class ClientsControllerTests : BaseClassFixture
    {
        public ClientsControllerTests(TestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task GetClientsAsAdmin()
        {
            SetupAdminClaimsViaHeaders();

            var response = await Client.GetAsync("api/clients", TestContext.Current.CancellationToken);

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetClientsWithoutPermissions()
        {
            Client.DefaultRequestHeaders.Clear();

            var response = await Client.GetAsync("api/clients", TestContext.Current.CancellationToken);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Redirect);

            //The redirect to login
            response.Headers.Location.ToString().Should().Contain(AuthenticationConsts.AccountLoginPage);
        }
    }
}
