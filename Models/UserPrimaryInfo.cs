using PocMvcNet8App.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PocMvcNet8App
{
    public class UserPrimaryInfo
    {
        public int Id { get; set; }
        //Id tied to IdentityUser table
        public string? UserId { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageType { get; set; }
        [Required]
        [Display(Name = "Profession")]
        [StringLength(50)]
        public string? JobTitle { get; set; }
        public int Age { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [StringLength(2000)]
        [DataType(DataType.MultilineText)]
        public string? About { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }
    }
}
