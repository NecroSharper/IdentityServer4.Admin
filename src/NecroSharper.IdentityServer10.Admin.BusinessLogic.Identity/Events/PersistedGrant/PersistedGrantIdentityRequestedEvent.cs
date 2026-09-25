using Skoruba.AuditLogging.Events;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Dtos.Grant;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Events.PersistedGrant
{
    public class PersistedGrantIdentityRequestedEvent : AuditEvent
    {
        public PersistedGrantDto PersistedGrant { get; set; }

        public PersistedGrantIdentityRequestedEvent(PersistedGrantDto persistedGrant)
        {
            PersistedGrant = persistedGrant;
        }
    }
}