using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;

namespace Skoruba.IdentityServer4.Admin.Api.Mappers
{
    public static class ClientApiMappers
    {
        static ClientApiMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientApiMapperProfile>(), NullLoggerFactory.Instance)
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }
        
        public static T ToClientApiModel<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }
    }
}