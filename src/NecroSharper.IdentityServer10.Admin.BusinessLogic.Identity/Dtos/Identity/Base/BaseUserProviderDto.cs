using NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Dtos.Identity.Base
{
    public class BaseUserProviderDto<TUserId> : IBaseUserProviderDto
    {
        public TUserId UserId { get; set; }

        object IBaseUserProviderDto.UserId => UserId;
    }
}