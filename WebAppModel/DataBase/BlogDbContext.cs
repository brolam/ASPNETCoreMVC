using System;
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
        }
    }
}
