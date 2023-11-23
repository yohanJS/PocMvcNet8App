﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PocMvcNet8App.Data;

namespace PocMvcNet8App.Models
{
    public class BlogPostModel
    {        
        public int Id { get; set; }
        public string? UserId { get; set; }
        [NotMapped]
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageType { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Author { get; set; }
        public string? TitleComment { get; set; }
        public string? CommentContent { get; set; }
        public List<CommentModel>? Comments { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }
    }
}
