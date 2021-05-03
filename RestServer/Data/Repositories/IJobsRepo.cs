using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FileData.Repositories
{
    public interface IJobsRepo
    {
        public Task<List<Job>> GetAllJobsAsync();
    }
}