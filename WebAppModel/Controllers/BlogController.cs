using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAppModel.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public BlogController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
