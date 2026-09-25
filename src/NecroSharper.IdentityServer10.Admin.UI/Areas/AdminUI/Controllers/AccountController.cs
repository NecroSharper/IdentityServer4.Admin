using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NecroSharper.IdentityServer10.Admin.UI.Configuration.Constants;
using System.Collections.Generic;

namespace NecroSharper.IdentityServer10.Admin.UI.Areas.AdminUI.Controllers
{
    [Authorize]
    [Area(CommonConsts.AdminUIArea)]
    public class AccountController : BaseController
    {
        public AccountController(ILogger<ConfigurationController> logger) : base(logger)
        {
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return new SignOutResult(new List<string> { AuthenticationConsts.SignInScheme, AuthenticationConsts.OidcAuthenticationScheme });
        }
    }
}
