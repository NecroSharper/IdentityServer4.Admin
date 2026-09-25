using NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Helpers;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Resources
{
    public interface IPersistedGrantAspNetIdentityServiceResources
    {
        ResourceMessage PersistedGrantDoesNotExist();

        ResourceMessage PersistedGrantWithSubjectIdDoesNotExist();
    }
}
