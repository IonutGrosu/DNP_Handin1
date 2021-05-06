using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace FileData.Repositories.Impl
{
    public class AdultsRepo : IAdultsRepo
    {
        public async Task<List<Adult>> GetAllAdultsAsync()
        {
            using CloudDbContext dbContext = new CloudDbContext();
            return dbContext.Adults.Include(a => a.JobTitle).ToList();
        }

        public async Task<Adult> GetAdultByIdAsync(int id)
        {
            using CloudDbContext dbContext = new CloudDbContext();
            return dbContext.Adults.Include(a => a.JobTitle).FirstOrDefault(a => a.Id == id);
        }

        public async Task AddAdultAsync(Adult adult)
        {
            using (CloudDbContext dbContext = new CloudDbContext())
            {
                Job j = await dbContext.Jobs.FirstOrDefaultAsync(j => j.Id == adult.JobTitle.Id);
                adult.JobTitle = j;
                await dbContext.Adults.AddAsync(adult);
                await dbContext.SaveChangesAsync();
            }
            
        }

        public async Task RemoveAdultAsync(int id)
        {
            using (CloudDbContext dbContext = new CloudDbContext())
            {
                Adult adultToRemove = await GetAdultByIdAsync(id);
                dbContext.Adults.Remove(adultToRemove);
                dbContext.SaveChanges();
            }
        }

        public async Task EditAdultAsync(Adult editedAdult)
        {
            using (CloudDbContext dbContext = new CloudDbContext())
            {
                await RemoveAdultAsync(editedAdult.Id);
                await AddAdultAsync(editedAdult);
                dbContext.SaveChanges();
            }
        }
    }
}