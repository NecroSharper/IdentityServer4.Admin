using AutoMapper;
using IdentityServer10.EntityFramework.Entities;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Dtos.Grant;
using NecroSharper.IdentityServer10.Admin.EntityFramework.Entities;
using NecroSharper.IdentityServer10.Admin.EntityFramework.Extensions.Common;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Mappers
{
    public class PersistedGrantMapperProfile : Profile
    {
        public PersistedGrantMapperProfile()
        {
            // entity to model
            CreateMap<PersistedGrant, PersistedGrantDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersistedGrantDataView, PersistedGrantDto>(MemberList.Destination);

            CreateMap<PagedList<PersistedGrantDataView>, PersistedGrantsDto>(MemberList.Destination)
                .ForMember(x => x.PersistedGrants,
                    opt => opt.MapFrom(src => src.Data));

            CreateMap<PagedList<PersistedGrant>, PersistedGrantsDto>(MemberList.Destination)
                .ForMember(x => x.PersistedGrants,
                    opt => opt.MapFrom(src => src.Data));            
        }
    }
}
