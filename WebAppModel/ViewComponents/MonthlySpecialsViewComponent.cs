using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAppModel.DataBase;

namespace WebAppModel.ViewComponents
{
    [ViewComponent]
    public class MonthlySpecialsViewComponent : ViewComponent
    {
        private readonly BlogDbContext blogDbContext;

        public MonthlySpecialsViewComponent(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }
        public IViewComponentResult Invoke()
        {
            var specials = blogDbContext.MonthlySpecials.ToArray();
            return View(specials);
        }
    }
}
