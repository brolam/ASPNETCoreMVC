using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppModel.Models;

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
            var blogItem = new BlogItem(){
                 Title = "My Blog post",
                 Posted = DateTime.Now,
                 Author = "Breno Marques",
                 Body = "My way"
            };
            return View(blogItem);
        }
    }
}
