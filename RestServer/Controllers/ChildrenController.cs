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
    public class ChildrenController : ControllerBase
    {
        private IFileAdapter fileAdapter;

        public ChildrenController(IFileAdapter fileAdapter)
        {
            this.fileAdapter = fileAdapter;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Child>>> GetChildrenAsync()
        {
            try
            {
                IList<Child> children = fileAdapter.GetAllChildren();
                Console.WriteLine(children.Count);
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
                Child child = fileAdapter.GetChildById(id);
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
                fileAdapter.RemoveChild(id);
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
                fileAdapter.EditChild(child);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}