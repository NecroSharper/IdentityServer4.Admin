using System.Collections.Generic;
using IdentityServer10.Models;
using Client = NecroSharper.IdentityServer10.Admin.EntityFramework.Configuration.Configuration.IdentityServer.Client;

namespace NecroSharper.IdentityServer10.Admin.EntityFramework.Configuration.Configuration
{
    public class IdentityServerData
    {
        public List<Client> Clients { get; set; } = new List<Client>();
        public List<IdentityResource> IdentityResources { get; set; } = new List<IdentityResource>();
        public List<ApiResource> ApiResources { get; set; } = new List<ApiResource>();
        public List<ApiScope> ApiScopes { get; set; } = new List<ApiScope>();
    }
}
