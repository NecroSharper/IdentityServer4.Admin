using Skoruba.AuditLogging.Events;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Events.PersistedGrant
{
    public class PersistedGrantDeletedEvent : AuditEvent
    {
        public string PersistedGrantKey { get; set; }

        public PersistedGrantDeletedEvent(string persistedGrantKey)
        {
            PersistedGrantKey = persistedGrantKey;
        }
    }
}