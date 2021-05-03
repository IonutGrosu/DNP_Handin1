using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FileData.Repositories.Impl
{
    public class ChildrenRepo : IChildrenRepo
    {
        public Task<List<Child>> GetAllChildrenAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Child> GetChildByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveChildAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task EditChildAsync(Child editedChild)
        {
            throw new System.NotImplementedException();
        }
    }
}