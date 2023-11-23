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
        public string? Title { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long", MinimumLength = 2)]
        [Display(Name = "Comment")]
        public string? Content { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
