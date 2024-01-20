using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Upload_Folder_MVC.Models
{
    public class Folder
    {
        [Key]
        public int Id { get; set; }

        public string FileName { get; set; }

        [Display(Name = "File Content")]
        [Required(ErrorMessage = "File Content is required")]
        public byte[] Content { get; set; }

        //Producer
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
