using NecroSharper.IdentityServer10.Admin.BusinessLogic.Helpers;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Resources
{
    public interface IPersistedGrantServiceResources
    {
        ResourceMessage PersistedGrantDoesNotExist();

        ResourceMessage PersistedGrantWithSubjectIdDoesNotExist();
    }
}
