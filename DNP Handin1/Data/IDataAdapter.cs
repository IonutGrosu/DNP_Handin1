using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DNP_Handin1.Data
{
    public interface IDataAdapter
    {
        public Task<List<Family>> GetAllFamiliesAsync();
        public Task<Family> GetFamilyWithAdultAsync(int adultId);
        public Task<Family> GetFamilyWithChildAsync(int childId);
        public Task<List<Adult>> GetAllAdultsAsync();
        public Task<Adult> GetAdultByIdAsync(int id);
        public Task AddAdultAsync(Adult adult);
        public Task RemoveAdultAsync(int id);
        public Task EditAdultAsync(Adult editedAdult);
        public Task<List<Child>> GetAllChildrenAsync();
        public Task<Child> GetChildByIdAsync(int id);
        public Task RemoveChildAsync(int id);
        public Task EditChildAsync(Child editedChild);
        public Task<List<Job>> GetAllJobsAsync();
    }
}