using Skoruba.AuditLogging.Events;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Events.Identity
{
    public class UserDeletedEvent<TUserDto> : AuditEvent
    {
        public TUserDto User { get; set; }

        public UserDeletedEvent(TUserDto user)
        {
            User = user;
        }
    }
}