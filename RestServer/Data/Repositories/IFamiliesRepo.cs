using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FileData.Repositories
{
    public interface IFamiliesRepo
    {
        public Task<List<Family>> GetAllFamiliesAsync();
        public Task<Family> GetFamilyWithAdultAsync(int adultId);
        public Task<Family> GetFamilyWithChildAsync(int childId);
    }
}