using System.ComponentModel.DataAnnotations;


namespace Upload_Folder_MVC.Models.ViewModel
{
    public class LoginVM
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is Required")]
        public String EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
    }
}
