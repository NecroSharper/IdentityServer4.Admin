using Skoruba.AuditLogging.Events;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Dtos.Identity;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Events.Identity
{
    public class ClaimUsersRequestedEvent<TUsersDto> : AuditEvent
    {
        public TUsersDto Users { get; set; }

        public ClaimUsersRequestedEvent(TUsersDto users)
        {
            Users = users;
        }
    }
}