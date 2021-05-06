using System.Threading.Tasks;
using Models;

namespace FileData.Repositories
{
    public interface IUsersRepo
    {
        Task<User> ValidateUserAsync(string UserName, string Password);
    }
}