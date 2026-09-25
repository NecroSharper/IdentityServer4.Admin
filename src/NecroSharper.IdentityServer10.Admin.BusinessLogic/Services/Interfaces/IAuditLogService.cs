using System;
using System.Threading.Tasks;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Dtos.Log;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task<AuditLogsDto> GetAsync(AuditLogFilterDto filters);

        Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan);
    }
}
