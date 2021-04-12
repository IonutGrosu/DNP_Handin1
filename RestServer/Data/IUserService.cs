using System.Threading.Tasks;
using Models;

namespace DNP_Handin1.Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string UserName, string Password);
    }
}