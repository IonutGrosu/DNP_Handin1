using System;
using System.Threading.Tasks;
using DNP_Handin1.Data;
using FileData.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace RestServer.Controllers
{
    [ApiController]
    [Route("login")]
    public class UsersController : ControllerBase
    {
        private IUsersRepository usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUserAsync([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                User user = await usersRepository.ValidateUserAsync(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}