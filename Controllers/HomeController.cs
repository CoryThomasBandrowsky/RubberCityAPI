using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Index()
        {
            var testString = JsonSerializer.Serialize("test time for the big boy");
            return new JsonResult(testString);
        }
    }
}
