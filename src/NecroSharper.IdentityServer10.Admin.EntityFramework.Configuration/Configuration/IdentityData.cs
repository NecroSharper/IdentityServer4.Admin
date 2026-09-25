using System.Collections.Generic;
using NecroSharper.IdentityServer10.Admin.EntityFramework.Configuration.Configuration.Identity;

namespace NecroSharper.IdentityServer10.Admin.EntityFramework.Configuration.Configuration
{
	public class IdentityData
    {
       public List<Role> Roles { get; set; }
       public List<User> Users { get; set; }
    }
}
