using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAppModel.Models;

namespace WebAppModel.DataBase
{
    public class BlogDbContext : DbContext
    {
        public DbSet<BlogItem> BlogItems {get; set;}

        public BlogDbContext(DbContextOptions<BlogDbContext> options ) : base(options)
        {
            Database.EnsureCreated();
            var rand = new Random();
            var blogItems = new BlogItem[]{
                new BlogItem{Title = $"Course details {rand.Next(101)}", Body = "ASP.NET Core, the Microsoft web development framework, includes an optimized developer experience, better performing runtime, and cross-platform support for Windows, Mac, and Linux. In this course, Jess Chadwick introduces the basics to get you up and running with ASP.NET Core, and creating your own professional quality applications" , Posted = DateTime.Now, Author = "Breno"},
                new BlogItem{Title = $"Course details {rand.Next(101)}", Body = "ASP.NET Core, the Microsoft web development framework, includes an optimized developer experience, better performing runtime, and cross-platform support for Windows, Mac, and Linux. In this course, Jess Chadwick introduces the basics to get you up and running with ASP.NET Core, and creating your own professional quality applications" , Posted = DateTime.Now, Author = "Breno"},
                new BlogItem{Title = $"Course details {rand.Next(101)}", Body = "ASP.NET Core, the Microsoft web development framework, includes an optimized developer experience, better performing runtime, and cross-platform support for Windows, Mac, and Linux. In this course, Jess Chadwick introduces the basics to get you up and running with ASP.NET Core, and creating your own professional quality applications" , Posted = DateTime.Now, Author = "Breno"}

            };
            this.BlogItems.AddRange(blogItems);
            this.SaveChanges();
        }
        
        public IQueryable<MonthlySpecial> MonthlySpecials
        {
            get
            {
                return new[]
                {
                    new MonthlySpecial {
                        Key = "calm",
                        Name = "California Calm Package",
                        Type = "Day Spa Package",
                        Price = 250,
                    },
                    new MonthlySpecial {
                        Key = "desert",
                        Name = "From Desert to Sea",
                        Type = "2 Day Salton Sea",
                        Price = 350,
                    },
                    new MonthlySpecial {
                        Key = "backpack",
                        Name = "Backpack Cali",
                        Type = "Big Sur Retreat",
                        Price = 620,
                    },
                    new MonthlySpecial {
                        Key = "taste",
                        Name = "Taste of California",
                        Type = "Tapas & Groves",
                        Price = 150,
                    },
                }.AsQueryable();
            }
        }

    }
}
