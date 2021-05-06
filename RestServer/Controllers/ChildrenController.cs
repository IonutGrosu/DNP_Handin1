using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileData.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace RestServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChildrenController : ControllerBase
    {
        private IChildrenRepo childrenRepo;

        public ChildrenController(IChildrenRepo childrenRepo)
        {
            this.childrenRepo = childrenRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Child>>> GetChildrenAsync()
        {
            try
            {
                IList<Child> children = await childrenRepo.GetAllChildrenAsync();
                return Ok(children);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Child>> GetChildByIdAsync([FromRoute] int id)
        {
            try
            {
                Child child = await childrenRepo.GetChildByIdAsync(id);
                return Ok(child);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task DeleteChildAsync([FromRoute] int id)
        {
            try
            {
                childrenRepo.RemoveChildAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        [HttpPatch]
        public async Task EditChildAsync([FromBody] Child child)
        {
            try
            {
                await childrenRepo.EditChildAsync(child);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}