using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using NecroSharper.IdentityServer10.STS.Identity.IntegrationTests.Tests.Base;
using Xunit;

namespace NecroSharper.IdentityServer10.STS.Identity.IntegrationTests.Tests
{
    public class HomeControllerTests : BaseClassFixture
    {
        public HomeControllerTests(TestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task EveryoneHasAccessToHomepage()
        {
            Client.DefaultRequestHeaders.Clear();

            // Act
            var response = await Client.GetAsync("/home/index", TestContext.Current.CancellationToken);

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}