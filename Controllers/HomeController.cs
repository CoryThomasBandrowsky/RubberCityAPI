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
        public IActionResult Index()
        {
            var response = new TestResponse("fuck my dad");
            return Ok(response);
        }
    }
}
