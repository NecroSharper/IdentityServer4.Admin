using Skoruba.AuditLogging.Events;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Dtos.Grant;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Events.PersistedGrant
{
    public class PersistedGrantRequestedEvent : AuditEvent
    {
        public PersistedGrantDto PersistedGrant { get; set; }

        public PersistedGrantRequestedEvent(PersistedGrantDto persistedGrant)
        {
            PersistedGrant = persistedGrant;
        }
    }
}