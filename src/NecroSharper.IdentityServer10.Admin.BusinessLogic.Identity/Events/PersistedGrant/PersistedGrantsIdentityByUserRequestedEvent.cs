using Skoruba.AuditLogging.Events;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Dtos.Grant;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Events.PersistedGrant
{
    public class PersistedGrantsIdentityByUserRequestedEvent : AuditEvent
    {
        public PersistedGrantsDto PersistedGrants { get; set; }

        public PersistedGrantsIdentityByUserRequestedEvent(PersistedGrantsDto persistedGrants)
        {
            PersistedGrants = persistedGrants;
        }
    }
}