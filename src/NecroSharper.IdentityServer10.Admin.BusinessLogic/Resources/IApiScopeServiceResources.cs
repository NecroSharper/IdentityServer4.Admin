using NecroSharper.IdentityServer10.Admin.BusinessLogic.Helpers;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Resources
{
    public interface IApiScopeServiceResources
    {
        ResourceMessage ApiScopeDoesNotExist();
        ResourceMessage ApiScopeExistsValue();
        ResourceMessage ApiScopeExistsKey();
        ResourceMessage ApiScopePropertyExistsValue();
        ResourceMessage ApiScopePropertyDoesNotExist();
        ResourceMessage ApiScopePropertyExistsKey();
    }
}