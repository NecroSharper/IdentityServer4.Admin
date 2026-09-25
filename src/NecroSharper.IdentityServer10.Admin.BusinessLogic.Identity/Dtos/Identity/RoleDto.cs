using System.ComponentModel.DataAnnotations;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Dtos.Identity.Base;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Dtos.Identity
{
    public class RoleDto<TKey> : BaseRoleDto<TKey>, IRoleDto
    {      
        [Required]
        public string Name { get; set; }
    }
}