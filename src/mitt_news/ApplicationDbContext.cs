using Microsoft.EntityFrameworkCore;
using mitt_news.Models;

namespace mitt_news
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}
        
         public DbSet<Advertisement> Advertisements { get; set; }
         public DbSet<Article> Articles { get; set; }
    }
}
