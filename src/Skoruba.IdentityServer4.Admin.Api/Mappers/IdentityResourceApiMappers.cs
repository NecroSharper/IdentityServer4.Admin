using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;

namespace Skoruba.IdentityServer4.Admin.Api.Mappers
{
    public static class IdentityResourceApiMappers
    {
        static IdentityResourceApiMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<IdentityResourceApiMapperProfile>(), NullLoggerFactory.Instance)
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static T ToIdentityResourceApiModel<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }
    }
}