using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNP_Handin1.Data;
using FileData.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace RestServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultsController : ControllerBase
    {
        private IAdultsRepo adultsRepo;

        public AdultsController(IAdultsRepo adultsRepo)
        {
            this.adultsRepo = adultsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdultsAsync()
        {
            try
            {
                IList<Adult> adults = await adultsRepo.GetAllAdultsAsync();
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> GetAdultWithIdAsync([FromRoute] int id)
        {
            try
            {
                Adult adult = await adultsRepo.GetAdultByIdAsync(id);
                return Ok(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task AddAdultAsync([FromBody] Adult adultToAdd)
        {
            try
            {
                await adultsRepo.AddAdultAsync(adultToAdd);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task DeleteAdultAsync([FromRoute] int id)
        {
            try
            {
                await adultsRepo.RemoveAdultAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [HttpPatch]
        public async Task EditAdultAsync([FromBody] Adult adult)
        {
            try
            {
                await adultsRepo.EditAdultAsync(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}