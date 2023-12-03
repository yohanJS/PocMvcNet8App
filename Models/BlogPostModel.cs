using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PocMvcNet8App.Data;

namespace PocMvcNet8App.Models
{
    public class BlogPostModel
    {        
        public int Id { get; set; }
        public string? UserId { get; set; }
        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageType { get; set; }
        [Required]
        [StringLength(50)]
        public string? Title { get; set; }
        [Required]
        [StringLength(2000)]
        [DataType(DataType.MultilineText)]
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Today;
        public string? Author { get; set; }
        [NotMapped]
        public string? CommentId { get; set; }
        [NotMapped]
        public string? TitleComment { get; set; }
        [NotMapped]
        public string? Comment { get; set; }
        [NotMapped]
        public string? SubComment { get; set; }
        [NotMapped]
        public List<CommentModel>? Comments { get; set; }
        [NotMapped]
        public List<SubCommentModel>? SubComments { get; set; }


        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }
    }
}
