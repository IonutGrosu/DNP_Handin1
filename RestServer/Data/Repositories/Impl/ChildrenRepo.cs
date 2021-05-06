using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace FileData.Repositories.Impl
{
    public class ChildrenRepo : IChildrenRepo
    {
        public async Task<List<Child>> GetAllChildrenAsync()
        {
            using CloudDbContext dbContext = new CloudDbContext();
            return dbContext.Children.ToList();
        }

        public async Task<Child> GetChildByIdAsync(int id)
        {
            using CloudDbContext dbContext = new CloudDbContext();
            return await dbContext.Children.Include(c => c.Pets).Include(c => c.Interests).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task RemoveChildAsync(int id)
        {
            using CloudDbContext dbContext = new CloudDbContext();
            Child childToRemove = await GetChildByIdAsync(id);
            dbContext.Children.Remove(childToRemove);
            dbContext.SaveChanges();
        }

        public async Task EditChildAsync(Child editedChild)
        {
            using (CloudDbContext dbContext = new CloudDbContext())
            {
                await RemoveChildAsync(editedChild.Id);
                editedChild.Interests = null;
                editedChild.Pets = null;
                dbContext.Children.Add(editedChild);
                dbContext.SaveChanges();
            }
        }
    }
}