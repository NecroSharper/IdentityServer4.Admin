using Microsoft.AspNetCore.Mvc;
using NecroSharper.IdentityServer10.Admin.UI.Configuration;

namespace NecroSharper.IdentityServer10.Admin.UI.ViewComponents
{
	public class IdentityServerLinkViewComponent : ViewComponent
    {
        private readonly AdminConfiguration _configuration;

        public IdentityServerLinkViewComponent(AdminConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IViewComponentResult Invoke()
        {
            var identityServerUrl = _configuration.IdentityServerBaseUrl;
            
            return View(model: identityServerUrl);
        }
    }
}
