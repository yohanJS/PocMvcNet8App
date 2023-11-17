using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PocMvcNet8App.Models;

namespace PocMvcNet8App.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<BlogModel>? blogModel { get; set; }
        public ICollection<BlogPostModel>? blogPostModel { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BlogModel>? blogModel { get; set; }
        public DbSet<BlogPostModel>? blogPostModel { get; set; }
    }
}

      