using IdentityServer10.EntityFramework.DbContexts;
using IdentityServer10.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using NecroSharper.IdentityServer10.Admin.EntityFramework.Interfaces;

namespace NecroSharperIdentityServer10Admin.Admin.EntityFramework.Shared.DbContexts
{
    public class IdentityServerPersistedGrantDbContext : PersistedGrantDbContext<IdentityServerPersistedGrantDbContext>, IAdminPersistedGrantDbContext
    {
        public IdentityServerPersistedGrantDbContext(DbContextOptions<IdentityServerPersistedGrantDbContext> options, OperationalStoreOptions storeOptions)
            : base(options, storeOptions)
        {
        }
    }
}







