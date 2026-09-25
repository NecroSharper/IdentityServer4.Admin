namespace NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces
{
    public interface IBaseUserClaimDto
    {
        int ClaimId { get; set; }
        object UserId { get; }
    }
}
