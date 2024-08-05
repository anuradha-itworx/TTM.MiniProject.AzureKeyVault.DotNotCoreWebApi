using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TTM.MiniProject.AzureKeyVault.DotNotCoreWebApi.Models;

namespace TTM.MiniProject.AzureKeyVault.DotNotCoreWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeyVaultController : ControllerBase
    {
        private readonly SecretClient _secretClient;

        public KeyVaultController(IOptions<KeyVaultSettings> keyVaultSettings)
        {
            var settings = keyVaultSettings.Value;
            var clientSecretCredential = new ClientSecretCredential(settings.TenantId, settings.ClientId, settings.ClientSecret);
            _secretClient = new SecretClient(new Uri(settings.Endpoint), clientSecretCredential);
        }

        [HttpGet("get-secret")]
        public async Task<IActionResult> GetSecret([FromQuery] string secretName)
        {
            try
            {
                Console.WriteLine($"Requesting secret '{secretName}' from Key Vault '{_secretClient.VaultUri}'");
                KeyVaultSecret secret = await _secretClient.GetSecretAsync(secretName);
                return Ok(secret.Value);
            }
            catch (RequestFailedException ex)
            {
                // Log the error details for troubleshooting
                Console.WriteLine($"RequestFailedException: Status: {ex.Status}, ErrorCode: {ex.ErrorCode}, Message: {ex.Message}");
                return BadRequest($"Key Vault request failed: {ex.Message}");
            }
            catch (CredentialUnavailableException ex)
            {
                // Log the error details for troubleshooting
                Console.WriteLine($"CredentialUnavailableException: {ex.Message}");
                return BadRequest($"Credential unavailable: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Log the error details for troubleshooting
                Console.WriteLine($"Exception: {ex.Message}");
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}
