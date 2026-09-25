// Original file comes from: https://github.com/damienbod/IdentityServer4AspNetCoreIdentityTemplate
// Modified by Jan Škoruba

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Certificates;
using Azure.Security.KeyVault.Secrets;
using NecroSharper.IdentityServer10.Shared.Configuration.Configuration.Common;

namespace NecroSharper.IdentityServer10.Shared.Configuration.Services
{
    public class AzureKeyVaultService
    {
        private readonly AzureKeyVaultConfiguration _azureKeyVaultConfiguration;

        public AzureKeyVaultService(AzureKeyVaultConfiguration azureKeyVaultConfiguration)
        {
            if (azureKeyVaultConfiguration == null)
            {
                throw new ArgumentException("missing azureKeyVaultConfiguration");
            }

            if (string.IsNullOrEmpty(azureKeyVaultConfiguration.AzureKeyVaultEndpoint))
            {
                throw new ArgumentException("missing keyVaultEndpoint");
            }

            _azureKeyVaultConfiguration = azureKeyVaultConfiguration;
        }

        public async Task<(X509Certificate2 ActiveCertificate, X509Certificate2 SecondaryCertificate)> GetCertificatesFromKeyVault()
        {
            (X509Certificate2 ActiveCertificate, X509Certificate2 SecondaryCertificate) certs = (null, null);

            var (certificateClient, secretClient) = BuildKeyVaultClients();

            var certificateItems = await GetAllEnabledCertificateVersionsAsync(certificateClient);
            var item = certificateItems.FirstOrDefault();
            if (item != null)
            {
                certs.ActiveCertificate = await GetCertificateAsync(item, secretClient);
            }

            if (certificateItems.Count > 1)
            {
                certs.SecondaryCertificate = await GetCertificateAsync(certificateItems[1], secretClient);
            }

            return certs;
        }

        /// <summary>
        /// Build KeyVaultClient according to authentication method
        /// </summary>
        /// <returns></returns>
        private (CertificateClient CertificateClient, SecretClient SecretClient) BuildKeyVaultClients()
        {
            TokenCredential credential = _azureKeyVaultConfiguration.UseClientCredentials
                ? new ClientSecretCredential(
                    _azureKeyVaultConfiguration.TenantId,
                    _azureKeyVaultConfiguration.ClientId,
                    _azureKeyVaultConfiguration.ClientSecret)
                : new DefaultAzureCredential();

            var keyVaultUri = new Uri(_azureKeyVaultConfiguration.AzureKeyVaultEndpoint);
            return (new CertificateClient(keyVaultUri, credential), new SecretClient(keyVaultUri, credential));
        }

        private async Task<List<CertificateProperties>> GetAllEnabledCertificateVersionsAsync(CertificateClient certificateClient)
        {
            var certificateVersions = new List<CertificateProperties>();

            await foreach (var certificateVersion in certificateClient.GetPropertiesOfCertificateVersionsAsync(
                               _azureKeyVaultConfiguration.IdentityServerCertificateName))
            {
                if (certificateVersion.Enabled == true)
                {
                    certificateVersions.Add(certificateVersion);
                }
            }

            return certificateVersions.OrderByDescending(certVersion => certVersion.CreatedOn).ToList();
        }

        private async Task<X509Certificate2> GetCertificateAsync(CertificateProperties certificate, SecretClient secretClient)
        {
            var certificatePrivateKeySecret = await secretClient.GetSecretAsync(
                _azureKeyVaultConfiguration.IdentityServerCertificateName, certificate.Version);
            var privateKeyBytes = Convert.FromBase64String(certificatePrivateKeySecret.Value.Value);
            var certificateWithPrivateKey = X509CertificateLoader.LoadPkcs12(
                privateKeyBytes, null, X509KeyStorageFlags.MachineKeySet);

            return certificateWithPrivateKey;
        }
    }
}
