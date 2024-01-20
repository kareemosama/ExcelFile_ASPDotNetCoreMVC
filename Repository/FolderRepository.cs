using Microsoft.EntityFrameworkCore;
using Upload_Folder_MVC.Data;
using Upload_Folder_MVC.Models;

namespace Upload_Folder_MVC.Repository
{
    public class FolderRepository:IFolderRepository
    {

        private readonly ApplicationDbContext _dbContext;
        public FolderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(Folder folder)
        {
            _dbContext.Add(folder);
            return Save();
        }

        public  bool Delete(Folder folder)
        {
            _dbContext.Remove(folder);
            return Save();
        }

        public async Task<IEnumerable<Folder>> GetAll()
        {
            return await _dbContext.Folder.ToListAsync();
        }

        public async Task<Folder> GetFolderById(int id)
        {
            return await _dbContext.Folder.FindAsync(id);
        }

        public bool Save()
        {
            var saved = _dbContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
