using PocMvcNet8App.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocMvcNet8App.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<BlogPostModel>? Posts { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

    }
}
