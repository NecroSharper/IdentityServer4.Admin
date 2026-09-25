using AutoMapper;
using Skoruba.AuditLogging.EntityFramework.Entities;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Dtos.Log;
using NecroSharper.IdentityServer10.Admin.EntityFramework.Entities;
using NecroSharper.IdentityServer10.Admin.EntityFramework.Extensions.Common;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Mappers
{
    public class LogMapperProfile : Profile
    {
        public LogMapperProfile()
        {
            CreateMap<Log, LogDto>(MemberList.Destination)
                .ReverseMap();
            
            CreateMap<PagedList<Log>, LogsDto>(MemberList.Destination)
                .ForMember(x => x.Logs, opt => opt.MapFrom(src => src.Data));

            CreateMap<AuditLog, AuditLogDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<AuditLog>, AuditLogsDto>(MemberList.Destination)
                .ForMember(x => x.Logs, opt => opt.MapFrom(src => src.Data));
        }
    }
}
