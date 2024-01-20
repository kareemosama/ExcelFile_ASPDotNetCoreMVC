using System.ComponentModel.DataAnnotations;


namespace Upload_Folder_MVC.Models.ViewModel
{
    public enum UserRoles { admin, user }
    public class RegisterVM 
    {

        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Full name is Required")]
        public String FullName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is Required")]
        public String EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Select a User Role")]
        [Required(ErrorMessage = "User Role is required")]
        public UserRoles userRoles {  get; set; }
    }
}

