using PocMvcNet8App.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocMvcNet8App.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public List<BlogPostModel>? Posts { get; set; }
        public List<UserPrimaryInfo>? users { get; set; }
        public List<CommentModel>? comments { get; set; }

    }
}
