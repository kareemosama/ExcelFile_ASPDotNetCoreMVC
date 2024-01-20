using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Upload_Folder_MVC.Models
{
    public class ApplicationUser: IdentityUser
    {

        [Display(Name = "Full Name")]
        public String FullName { get; set; }
    }
}
