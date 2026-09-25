using NecroSharper.IdentityServer10.Admin.BusinessLogic.Helpers;

namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Resources
{
    public interface IApiResourceServiceResources
    {
        ResourceMessage ApiResourceDoesNotExist();
        ResourceMessage ApiResourceExistsValue();
        ResourceMessage ApiResourceExistsKey();
        ResourceMessage ApiSecretDoesNotExist();
        ResourceMessage ApiResourcePropertyDoesNotExist();
        ResourceMessage ApiResourcePropertyExistsKey();
        ResourceMessage ApiResourcePropertyExistsValue();
    }
}