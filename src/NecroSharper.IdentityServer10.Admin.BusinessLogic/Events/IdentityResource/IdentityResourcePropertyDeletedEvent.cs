using Skoruba.AuditLogging.Events;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Dtos.Configuration;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Events.IdentityResource
{
    public class IdentityResourcePropertyDeletedEvent : AuditEvent
    {
        public IdentityResourcePropertiesDto IdentityResourceProperty { get; set; }

        public IdentityResourcePropertyDeletedEvent(IdentityResourcePropertiesDto identityResourceProperty)
        {
            IdentityResourceProperty = identityResourceProperty;
        }
    }
}