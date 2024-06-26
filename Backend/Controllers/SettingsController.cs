using Merchanmusic.Data.Auth0;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Merchanmusic.Controllers
{
    [Route("api/settings")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SettingsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("auth")]
        public IActionResult GetPublicAuthSettings()
        {
            try
            {
                var Auth0SettingsDto = new PublicAuthSettings()
                {
                    Domain = _configuration.GetValue<string>("Auth0:Domain"),
                    ClientId = _configuration.GetValue<string>("Auth0:ClientId")
                };
                return Ok(Auth0SettingsDto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
