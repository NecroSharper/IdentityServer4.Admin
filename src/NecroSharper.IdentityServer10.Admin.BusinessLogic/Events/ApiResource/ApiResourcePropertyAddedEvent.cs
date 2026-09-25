using Skoruba.AuditLogging.Events;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Dtos.Configuration;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Events.ApiResource
{
    public class ApiResourcePropertyAddedEvent : AuditEvent
    {
        public ApiResourcePropertyAddedEvent(ApiResourcePropertiesDto apiResourceProperty)
        {
            ApiResourceProperty = apiResourceProperty;
        }

        public ApiResourcePropertiesDto ApiResourceProperty { get; set; }
    }
}