using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;
using Skoruba.AuditLogging.EntityFramework.Entities;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Dtos.Log;
using NecroSharper.IdentityServer10.Admin.EntityFramework.Entities;
using NecroSharper.IdentityServer10.Admin.EntityFramework.Extensions.Common;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Mappers
{
    public static class LogMappers
    {
        internal static IMapper Mapper { get; }

        static LogMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<LogMapperProfile>(), NullLoggerFactory.Instance)
                .CreateMapper();
        }

        public static LogDto ToModel(this Log log)
        {
            return Mapper.Map<LogDto>(log);
        }

        public static LogsDto ToModel(this PagedList<Log> logs)
        {
            return Mapper.Map<LogsDto>(logs);
        }

        public static AuditLogsDto ToModel<TAuditLog>(this PagedList<TAuditLog> auditLogs)
            where TAuditLog : AuditLog
        {
            return Mapper.Map<AuditLogsDto>(auditLogs);
        }

        public static AuditLogDto ToModel(this AuditLog auditLog)
        {
            return Mapper.Map<AuditLogDto>(auditLog);
        }

        public static Log ToEntity(this LogDto log)
        {
            return Mapper.Map<Log>(log);
        }
    }
}
