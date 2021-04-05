using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Models;

namespace DNP_Handin1.Data
{
    public class RestAdapter : IDataAdapter
    {
        public Task<List<Family>> GetAllFamiliesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Family> GetFamilyWithAdultAsync(int adultId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Family> GetFamilyWithChildAsync(int childId)
        {
            throw new System.NotImplementedException();
        }

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

        public Task<List<Job>> GetAllJobsAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}