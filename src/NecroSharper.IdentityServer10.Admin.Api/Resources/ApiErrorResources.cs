using NecroSharper.IdentityServer10.Admin.Api.ExceptionHandling;

namespace NecroSharper.IdentityServer10.Admin.Api.Resources
{
    public class ApiErrorResources : IApiErrorResources
    {
        public virtual ApiError CannotSetId()
        {
            return new ApiError
            {
                Code = nameof(CannotSetId),
                Description = ApiErrorResource.CannotSetId
            };
        }
    }
}