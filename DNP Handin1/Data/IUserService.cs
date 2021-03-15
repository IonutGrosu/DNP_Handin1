using Models;

namespace DNP_Handin1.Data
{
    public interface IUserService
    {
        User ValidateUser(string UserName, string Password);
    }
}