using System.Collections.Generic;

namespace Skoruba.IdentityServer4.STS.Identity.Configuration
{
    public class CultureConfiguration
    {
        public static readonly string[] AvailableCultures = { "en", "id", "fa", "fr", "ru", "sv", "zh", "es", "da", "de", "nl", "fi", "pt", "ar" };
        public static readonly string DefaultRequestCulture = "en";

        public List<string> Cultures { get; set; }
        public string DefaultCulture { get; set; } = DefaultRequestCulture;
    }
}
