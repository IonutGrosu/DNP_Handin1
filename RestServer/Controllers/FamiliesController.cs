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
                Console.WriteLine(families.Count);
                return Ok(families);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}