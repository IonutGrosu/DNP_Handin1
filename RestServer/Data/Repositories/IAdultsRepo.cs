using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FileData.Repositories
{
    public interface IAdultsRepo
    {
        public Task<List<Adult>> GetAllAdultsAsync();
        public Task<Adult> GetAdultByIdAsync(int id);
        public Task AddAdultAsync(Adult adult);
        public Task RemoveAdultAsync(int id);
        public Task EditAdultAsync(Adult editedAdult);
    }
}