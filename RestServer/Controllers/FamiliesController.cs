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
    public class FamiliesController : ControllerBase
    {
        private IFileAdapter fileAdapter;

        public FamiliesController(IFileAdapter fileAdapter)
        {
            this.fileAdapter = fileAdapter;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamiliesAsync()
        {
            try
            {
                IList<Family> families = fileAdapter.GetAllFamilies();
                return Ok(families);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("adult/{id:int}")]
        public async Task<ActionResult<Family>> GetFamilyWithAdult([FromRoute] int id)
        {
            try
            {
                Family family = fileAdapter.GetFamilyWithAdult(id);
                return Ok(family);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpGet]
        [Route("child/{id:int}")]
        public async Task<ActionResult<Family>> GetFamilyWithChild([FromRoute] int id)
        {
            try
            {
                Family family = fileAdapter.GetFamilyWithChild(id);
                return Ok(family);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}