namespace PocMvcNet8App.Models
{
    public class SubCommentModel
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int? CommentId { get; set; }
        public string? Comment { get; set; }
        public string? Author { get; set; }
        public DateTime Created { get; set; } = DateTime.Today;

    }
}
