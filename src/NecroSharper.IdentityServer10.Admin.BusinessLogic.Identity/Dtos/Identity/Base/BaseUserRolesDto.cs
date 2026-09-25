using NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Dtos.Identity.Base
{
    public class BaseUserRolesDto<TKey> : IBaseUserRolesDto
    {
        public TKey UserId { get; set; }

        public TKey RoleId { get; set; }

        object IBaseUserRolesDto.UserId => UserId;

        object IBaseUserRolesDto.RoleId => RoleId;
    }
}