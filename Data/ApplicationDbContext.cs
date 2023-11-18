using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PocMvcNet8App.Models;

namespace PocMvcNet8App.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<BlogPostModel>? blogPostModel { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BlogPostModel>? blogPostModel { get; set; }
        public DbSet<PocMvcNet8App.Models.BlogModel> BlogModel { get; set; } = default!;
    }
}

      