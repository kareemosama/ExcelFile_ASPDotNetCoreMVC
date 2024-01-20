using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Upload_Folder_MVC.Models;
using Upload_Folder_MVC.Models.ViewModel;
using Upload_Folder_MVC.Repository;

namespace Upload_Folder_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFolderRepository _Folder;
       private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger,IFolderRepository folder,UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _Folder = folder;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Folder> Folder = await _Folder.GetAll();

            List<FolderVM> FolderVM = new List<FolderVM>();


            foreach (var folder in Folder )
            {
                
                var userName = await _userManager.FindByIdAsync(folder.UserId);

                var foldervm = new FolderVM()
                {
                    FileId = folder.Id,
                    FileName = folder.FileName,
                    UserName = userName.FullName
                };

                FolderVM.Add(foldervm);
            }


            

            return View(FolderVM);
        }

        public IActionResult Upload() {

          
            return View();

        }

        [HttpPost]
        public async Task<IActionResult>  Upload(IFormFile file) {


            

            if (file != null && file.Length>0) {

               using (var mermoryStream = new MemoryStream())
                {
                    file.CopyTo(mermoryStream);

                    var Folder = new Folder
                    {
                        FileName = file.FileName,
                        Content = mermoryStream.ToArray(),
                        UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)


                };
                    _Folder.Add(Folder);
                }

            }
            else
            {
                TempData["Error"] = "This file is empty ";
                return View();

            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Download(int id) { 

            var file =  await _Folder.GetFolderById(id);
           
            
            if (file != null) {

                return File(file.Content, "application/octet-stream",file.FileName);
            }

            return NotFound();
        
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var folderDetails = await _Folder.GetFolderById(id);
            if (folderDetails == null) return View("NotFound");

            _Folder.Delete(folderDetails);
            return RedirectToAction("Index");

        }


        public async Task<IActionResult> Filter(string searchString)
        {
            var Folder = await _Folder.GetAll();
            List<FolderVM> FolderVM = new List<FolderVM>();

            foreach (var folder in Folder)
            {
                var user = await _userManager.FindByIdAsync(folder.UserId);
                var Foldervm = new FolderVM
                {
                    FileName = folder.FileName,
                    FileId = folder.Id,
                    UserName = user.UserName
                };

                FolderVM.Add(Foldervm);

            }


            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = FolderVM.Where(n => n.FileName.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", FolderVM);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}