using Skoruba.AuditLogging.Events;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Dtos.Configuration;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Events.ApiResource
{
    public class ApiResourceRequestedEvent : AuditEvent
    {
        public int ApiResourceId { get; set; }
        public ApiResourceDto ApiResource { get; set; }

        public ApiResourceRequestedEvent(int apiResourceId, ApiResourceDto apiResource)
        {
            ApiResourceId = apiResourceId;
            ApiResource = apiResource;
        }
    }
}