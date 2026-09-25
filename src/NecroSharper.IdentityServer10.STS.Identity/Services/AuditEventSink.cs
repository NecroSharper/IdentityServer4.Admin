using System.Threading.Tasks;
using IdentityServer10.Events;
using IdentityServer10.Services;
using Microsoft.Extensions.Logging;

namespace NecroSharper.IdentityServer10.STS.Identity.Services
{
    public class AuditEventSink : DefaultEventSink
    {
        public AuditEventSink(ILogger<DefaultEventService> logger) : base(logger)
        {
        }

        public override Task PersistAsync(Event evt)
        {
            return base.PersistAsync(evt);
        }
    }
}