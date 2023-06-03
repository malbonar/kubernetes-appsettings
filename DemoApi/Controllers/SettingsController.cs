using DemoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly Settings _settings;

        public SettingsController(IOptions<Settings> settings) => _settings = settings.Value;

        /// <summary>
        /// /api/settings
        /// Simple endpoint to fetch a value from the appsettings file. 
        /// This value is going to be overridden in a kubernetes appsettings file configMap.
        /// So we can confirm the configMap setup to override appsettings.json in kubernetes is working as expected
        /// </summary>
        /// <returns>Settings.Message from appsettings</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_settings.Message);
        }
    }
}
