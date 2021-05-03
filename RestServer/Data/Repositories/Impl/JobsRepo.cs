using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace FileData.Repositories.Impl
{
    public class JobsRepo : IJobsRepo
    {
        public async Task<List<Job>> GetAllJobsAsync()
        {
            using CloudDbContext dbContext = new CloudDbContext();
            return dbContext.Jobs.ToList();
        }
    }
}