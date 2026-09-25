using System.ComponentModel.DataAnnotations;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Dtos.Identity.Base;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Dtos.Identity
{
    public class RoleClaimDto<TKey> : BaseRoleClaimDto<TKey>, IRoleClaimDto
    {
        [Required]
        public string ClaimType { get; set; }


        [Required]
        public string ClaimValue { get; set; }
    }
}
