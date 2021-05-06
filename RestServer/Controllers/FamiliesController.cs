using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNP_Handin1.Data;
using FileData;
using FileData.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace RestServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliesController : ControllerBase
    {
        private IFamiliesRepo familiesRepo;

        public FamiliesController(IFamiliesRepo familiesRepo)
        {
            this.familiesRepo = familiesRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamiliesAsync()
        {
            try
            {
                IList<Family> families = await familiesRepo.GetAllFamiliesAsync();
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
        public async Task<ActionResult<Family>> GetFamilyWithAdultAsync([FromRoute] int id)
        {
            try
            {
                Family family = await familiesRepo.GetFamilyWithAdultAsync(id);
                return Ok(family);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("child/{id:int}")]
        public async Task<ActionResult<Family>> GetFamilyWithChildAsync([FromRoute] int id)
        {
            try
            {
                Family family = await familiesRepo.GetFamilyWithChildAsync(id);
                return Ok(family);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}