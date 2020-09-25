using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAppModel.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public BlogController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            ViewBag.Title = "My Blog post";
            ViewBag.Posted = DateTime.Now;
            ViewBag.Author = "Breno Marques";
            ViewBag.Body = "My way";
            return View();
        }
    }
}
