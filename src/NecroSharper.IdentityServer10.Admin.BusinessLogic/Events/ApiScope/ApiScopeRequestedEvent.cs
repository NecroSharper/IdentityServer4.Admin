using Skoruba.AuditLogging.Events;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Dtos.Configuration;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Events.ApiScope
{
    public class ApiScopeRequestedEvent : AuditEvent
    {
        public ApiScopeDto ApiScopes { get; set; }

        public ApiScopeRequestedEvent(ApiScopeDto apiScopes)
        {
            ApiScopes = apiScopes;
        }
    }
}