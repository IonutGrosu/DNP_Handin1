using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FileData.Repositories
{
    public interface IChildrenRepo
    {
        public Task<List<Child>> GetAllChildrenAsync();
        public Task<Child> GetChildByIdAsync(int id);
        public Task RemoveChildAsync(int id);
        public Task EditChildAsync(Child editedChild);
    }
}