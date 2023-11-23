using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PocMvcNet8App.Models;

namespace PocMvcNet8App.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<UserPrimaryInfo>? userPrimaryInfo { get; set; }
        public ICollection<BlogPostModel>? blogPostModel { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserPrimaryInfo>? UserPrimaryInfo { get; set; }
        public DbSet<BlogPostModel>? blogPostModel { get; set; }
        public DbSet<BlogModel> BlogModel { get; set; } = default!;
        public DbSet<CommentModel>? CommentModel { get; set; }
    }
}

      