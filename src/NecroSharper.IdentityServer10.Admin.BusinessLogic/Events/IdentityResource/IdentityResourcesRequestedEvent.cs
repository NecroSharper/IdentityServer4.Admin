using Skoruba.AuditLogging.Events;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Dtos.Configuration;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Events.IdentityResource
{
    public class IdentityResourcesRequestedEvent : AuditEvent
    {
        public IdentityResourcesDto IdentityResources { get; }

        public IdentityResourcesRequestedEvent(IdentityResourcesDto identityResources)
        {
            IdentityResources = identityResources;
        }
    }
}