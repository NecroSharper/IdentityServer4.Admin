using Microsoft.EntityFrameworkCore;
using NecroSharper.IdentityServer10.Admin.EntityFramework.Entities;

namespace NecroSharper.IdentityServer10.Admin.EntityFramework.Interfaces
{
    public interface IAdminLogDbContext
    {
        DbSet<Log> Logs { get; set; }
    }
}
