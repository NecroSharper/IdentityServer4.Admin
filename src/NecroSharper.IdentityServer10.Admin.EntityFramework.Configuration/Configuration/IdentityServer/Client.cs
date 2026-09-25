using System.Collections.Generic;
using NecroSharper.IdentityServer10.Admin.EntityFramework.Configuration.Configuration.Identity;

namespace NecroSharper.IdentityServer10.Admin.EntityFramework.Configuration.Configuration.IdentityServer
{
    public class Client : global::IdentityServer10.Models.Client
    {
        public List<Claim> ClientClaims { get; set; } = new List<Claim>();
    }
}
