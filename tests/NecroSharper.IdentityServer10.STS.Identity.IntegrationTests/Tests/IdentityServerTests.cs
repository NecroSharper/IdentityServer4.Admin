using System.Threading.Tasks;
using FluentAssertions;
using IdentityModel.Client;
using NecroSharper.IdentityServer10.STS.Identity.IntegrationTests.Tests.Base;
using Xunit;

namespace NecroSharper.IdentityServer10.STS.Identity.IntegrationTests.Tests
{
    public class IdentityServerTests : BaseClassFixture
    {
        public IdentityServerTests(TestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task CanShowDiscoveryEndpoint()
        {
            var disco = await Client.GetDiscoveryDocumentAsync("http://localhost", TestContext.Current.CancellationToken);

            disco.Should().NotBeNull();
            disco.IsError.Should().Be(false);

            disco.KeySet.Keys.Count.Should().Be(1);
        }
    }
}
