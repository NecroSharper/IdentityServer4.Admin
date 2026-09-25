using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;

namespace NecroSharper.IdentityServer10.Admin.Api.Mappers
{
    public static class ApiScopeApiMappers
    {
        static ApiScopeApiMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiScopeApiMapperProfile>(), NullLoggerFactory.Instance)
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static T ToApiScopeApiModel<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }
    }
}