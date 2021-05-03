using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FileData.Repositories.Impl
{
    public class FamiliesRepo : IFamiliesRepo
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
    }
}