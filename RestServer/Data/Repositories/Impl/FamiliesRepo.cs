using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace FileData.Repositories.Impl
{
    public class FamiliesRepo : IFamiliesRepo
    {
        public async Task<List<Family>> GetAllFamiliesAsync()
        {
            using CloudDbContext dbContext = new CloudDbContext();
            return dbContext.Families.Include(f => f.Adults)
                .Include(f => f.Children).Include(f => f.Pets).ToList();
        }

        public async Task<Family> GetFamilyWithAdultAsync(int adultId)
        {
            Family familyToReturn = null;
            using (CloudDbContext dbContext = new CloudDbContext())
            {
                //get adult with id from adults db set
                Adult dbAdult = dbContext.Adults.Include(f => f.JobTitle).FirstOrDefault(a => a.Id == adultId);
                //query the family with the above adult
                
                if (dbAdult != null)
                {
                    familyToReturn = dbContext.Families.Include(f => f.Adults)
                        .FirstOrDefault(f => f.Adults.Contains(dbAdult));
                }
            }
            return familyToReturn;
        }

        public async Task<Family> GetFamilyWithChildAsync(int childId)
        {
            Family familyToReturn = null;
            using (CloudDbContext dbContext = new CloudDbContext())
            {
                Child dbChild = dbContext.Children.Include(f => f.Interests).Include(f => f.Pets).FirstOrDefault(c => c.Id == childId);
                
                if (dbChild != null)
                {
                    familyToReturn = dbContext.Families.Include(f => f.Children)
                        .FirstOrDefault(f => f.Children.Contains(dbChild));
                }
            }
            return familyToReturn;
        }
    }
}