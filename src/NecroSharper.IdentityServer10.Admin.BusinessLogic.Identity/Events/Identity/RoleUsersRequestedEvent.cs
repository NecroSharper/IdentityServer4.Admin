using Skoruba.AuditLogging.Events;
using NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Dtos.Identity;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Events.Identity
{
    public class RoleUsersRequestedEvent<TUsersDto> : AuditEvent
    {
        public TUsersDto Users { get; set; }

        public RoleUsersRequestedEvent(TUsersDto users)
        {
            Users = users;
        }
    }
}