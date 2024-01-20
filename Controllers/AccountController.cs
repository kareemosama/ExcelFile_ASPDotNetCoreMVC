using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Upload_Folder_MVC.Data;
using Upload_Folder_MVC.Data.Static;
using Upload_Folder_MVC.Models;
using Upload_Folder_MVC.Models.ViewModel;

namespace Upload_Folder_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly  ApplicationDbContext _Dbcontext;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager , ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _Dbcontext = dbContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() =>  View(new LoginVM());
        

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);

            if(user != null)
            {
                var pass = await _userManager.CheckPasswordAsync(user,loginVM.Password);
                if(pass) {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["Error"] = "Wrond credentials. Please TryAgain!";
                    return View(loginVM);
                }
            }
            TempData["Error"] = "Wrond credentials. Please TryAgain!";
            return View(loginVM);
        }

        public IActionResult Register() => View(new RegisterVM());


        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }
            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);
           
            if (newUserResponse.Errors.Count()>0) {
                var error = newUserResponse.Errors.ToList()[0];
                TempData["Error"] = "error" + error.Description;
                return View(registerVM);
            }


            //var x = Data.Static.UserRoles.Admin;

            if (newUserResponse.Succeeded && registerVM.userRoles.HasFlag(Models.ViewModel.UserRoles.user)) await _userManager.AddToRoleAsync(newUser, Data.Static.UserRoles.User);
            else if(newUserResponse.Succeeded) { await _userManager.AddToRoleAsync(newUser, Data.Static.UserRoles.Admin); }

            return View("RegisterCompleted");

        }
           

        


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
