using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FileData.Repositories.Impl
{
    public class AdultsRepo : IAdultsRepo
    {
        public Task<List<Adult>> GetAllAdultsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Adult> GetAdultByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAdultAsync(Adult adult)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAdultAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task EditAdultAsync(Adult editedAdult)
        {
            throw new System.NotImplementedException();
        }
    }
}