using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace FileData.Repositories.Impl
{
    public class UsersRepository : IUsersRepository
    {
        public async Task<User> ValidateUserAsync(string UserName, string Password)
        {
            using CloudDbContext dbContext = new CloudDbContext();
            User temp = await dbContext.Users.FirstOrDefaultAsync(user => user.UserName.Equals(UserName));
            if (temp == null)
            {
                throw new Exception("User not found");
            }

            if (!temp.Password.Equals(Password))
            {
                throw new Exception("Incorrect password");
            }

            return temp;
        }
    }
}