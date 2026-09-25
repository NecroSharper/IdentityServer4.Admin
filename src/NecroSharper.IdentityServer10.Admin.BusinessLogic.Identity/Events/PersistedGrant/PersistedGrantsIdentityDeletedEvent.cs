using Skoruba.AuditLogging.Events;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Events.PersistedGrant
{
    public class PersistedGrantsIdentityDeletedEvent : AuditEvent
    {
        public string UserId { get; set; }

        public PersistedGrantsIdentityDeletedEvent(string userId)
        {
            UserId = userId;
        }
    }
}