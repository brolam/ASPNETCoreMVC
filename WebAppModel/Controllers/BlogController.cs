using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppModel.DataBase;
using WebAppModel.Models;
using WebAppModel.Models.Dtos;

namespace WebAppModel.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        private readonly BlogDbContext blogDbContext;
        private readonly ILogger<HomeController> _logger;

        public BlogController(BlogDbContext blogDbContext, ILogger<HomeController> logger)
        {
            this.blogDbContext = blogDbContext;
            _logger = logger;
        }

        [Route("")]
        public IActionResult Index()
        {
            var blobItems = blogDbContext.BlogItems.OrderByDescending(
                blobItem => blobItem.Posted
            ).ToArray();
            return View(blobItems);
        }

        [Route("post/{id}")]
        public IActionResult Post(int id)
        {
            var blogItem = blogDbContext.BlogItems.Find(id);
            if ( blogItem == null ) return NotFound();
            return View(blogItem);
        }

        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("create")]
        public IActionResult Create(BlogItemDto blogItemDto)
        {
            if ( ! ModelState.IsValid) return View();
            var blogItem = new BlogItem
            {
                Title = blogItemDto.Title,
                Body = blogItemDto.Body,
                Author = User.Identity.Name,
                Posted = DateTime.Now
            };
            blogDbContext.BlogItems.Add(blogItem);
            blogDbContext.SaveChanges();
            return RedirectToAction("Post", "Blog", new {id = blogItem.Id});
        }
    }
}
