using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Index(int page = 0)
        {
            var pageSize = 2;
            var totalPosts = blogDbContext.BlogItems.Count();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;

            var posts =
                blogDbContext.BlogItems
                    .OrderByDescending(x => x.Posted)
                    .Skip(pageSize * page)
                    .Take(pageSize)
                    .ToArray();

            if(Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView(posts);

            return View(posts);
        }

        [Route("post/{id}")]
        public IActionResult Post(int id)
        {
            var blogItem = blogDbContext.BlogItems.Find(id);
            if ( blogItem == null ) return NotFound();
            return View(blogItem);
        }

        [Authorize, HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize, HttpPost, Route("create")]
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
