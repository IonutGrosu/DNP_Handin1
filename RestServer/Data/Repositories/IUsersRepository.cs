using System.Threading.Tasks;
using Models;

namespace FileData.Repositories
{
    public interface IUsersRepository
    {
        Task<User> ValidateUserAsync(string UserName, string Password);
    }
}