using Microsoft.AspNetCore.Mvc;
using RubberCityAPI.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace RubberCityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = new TestResponse("dad time");
            return Ok(response);
        }
    }
}
