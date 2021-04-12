using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNP_Handin1.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace RestServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultsController : ControllerBase
    {
        private IFileAdapter fileAdapter;

        public AdultsController(IFileAdapter fileAdapter)
        {
            this.fileAdapter = fileAdapter;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdultsAsync()
        {
            try
            {
                IList<Adult> adults = await fileAdapter.GetAllAdultsAsync();
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
                Adult adult = await fileAdapter.GetAdultByIdAsync(id);
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
                fileAdapter.AddAdultAsync(adultToAdd);
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
                fileAdapter.RemoveAdultAsync(id);
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
                fileAdapter.EditAdultAsync(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}