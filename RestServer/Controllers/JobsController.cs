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
    public class JobsController : ControllerBase
    {
        private IJobsRepo JobsRepo;

        public JobsController(IJobsRepo jobsRepo)
        {
            this.JobsRepo = jobsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Job>>> GetJobsAsync()
        {
            try
            {
                IList<Job> jobs = await JobsRepo.GetAllJobsAsync();
                return Ok(jobs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}