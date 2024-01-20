using Microsoft.EntityFrameworkCore;
using Upload_Folder_MVC.Models;

namespace Upload_Folder_MVC.Repository
{
    public interface IFolderRepository
    {

        Task<IEnumerable<Folder>> GetAll();

        bool Add(Folder folder);

        bool Delete(Folder folder);

        Task<Folder> GetFolderById(int id);

        bool Save();
       
    }
}
