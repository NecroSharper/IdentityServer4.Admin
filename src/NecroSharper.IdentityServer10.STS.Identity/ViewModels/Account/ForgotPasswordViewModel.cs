using System.ComponentModel.DataAnnotations;
using NecroSharper.IdentityServer10.Shared.Configuration.Configuration.Identity;

namespace NecroSharper.IdentityServer10.STS.Identity.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public LoginResolutionPolicy? Policy { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }
    }
}
