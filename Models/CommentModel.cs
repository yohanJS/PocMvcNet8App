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
        [Required]
        [StringLength(50)]
        public string? TitleComment { get; set; }
        [Required]
        [StringLength(2000)]
        [DataType(DataType.MultilineText)]
        public string? Comment { get; set; }
        public string? Author { get; set; }
        public DateTime Created { get; set; } = DateTime.Today;

    }
}
