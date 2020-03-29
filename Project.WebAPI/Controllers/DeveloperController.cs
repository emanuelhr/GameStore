using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Model;
using Project.Model.Common;
using Project.Service.Common;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperService _service;
        private readonly ILogger<IDeveloperService> _logger;

        public DeveloperController(IDeveloperService service, ILogger<IDeveloperService> logger)
        {
            _service = service;
            _logger = logger;
        }
        // GET: api/developer
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IDeveloper>>> Get()
        {
            try
            {
                return Ok(await _service.GetDevelopers());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to retrieve developers : {ex}");
                return BadRequest("Failed to retrieve Developers");
            }
            
        }

        // GET: api/developer/5
        [HttpGet("{id}", Name = "Get_developer")]
        public async Task<ActionResult<IDeveloper>> Get(int id)
        {
            try
            {
                return Ok(await _service.GetDeveloperById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to retrieve developer : {ex}");
                
            }
            return BadRequest("Failed to retrieve Developer");

        }

        // POST: api/developer/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Developer developer)
        {
            try
            {

                if (await _service.CreateDeveloper(developer)==1)
                {
                   var createdDeveloper=await _service.GetLastDeveloperAsync();
                    return Created("api/Developer", createdDeveloper);
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create developer : {ex}");
              
            }
            return BadRequest("Failed to create Developer");

        }

        // PUT: api/developer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Developer developer)
        {

            try
            {
                if (await _service.GetDeveloperById(id)==null)
                {
                    return NotFound("Developer not found");
                }

               return Ok ( await _service.UpdateDeveloper(id, developer));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update developer : {ex}");

            }
            return BadRequest("Failed to update Developer");


        }

        // DELETE: api/developer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                if (!await _service.DeveloperExists(id))
                {
                    return NotFound("Developer doesn't exist");
                }
                await _service.DeleteDeveloperAsync(id);
                return Ok("Successfully deleted developer");
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to Delete deveoper {ex}");
            }
            return NotFound("Developer doesn't exist");
           

           
        }
    }
}
