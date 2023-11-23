using PocMvcNet8App.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocMvcNet8App.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int BlogPostId { get; set; }
        public string? TitleComment { get; set; }
        public string? Comment { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
