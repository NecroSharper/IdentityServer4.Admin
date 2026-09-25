using Skoruba.AuditLogging.Events;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Events.Identity
{
    public class RoleClaimRequestedEvent<TRoleClaimsDto> : AuditEvent
    {
        public TRoleClaimsDto RoleClaim { get; set; }

        public RoleClaimRequestedEvent(TRoleClaimsDto roleClaim)
        {
            RoleClaim = roleClaim;
        }
    }
}