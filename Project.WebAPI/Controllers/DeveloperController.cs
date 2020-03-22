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
        // GET: api/Developer
        
        [HttpGet]
        public async Task<IEnumerable<IDeveloper>> Get()
        {
            return  await _service.GetDevelopers();
        }

        // GET: api/Developer/5
        [HttpGet("{id}", Name = "Get_developer")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Developer
        [HttpPost]
        public async Task Post([FromBody] Developer developer)
        {
            

            await   _service.CreateDeveloper(developer);

        }

        // PUT: api/Developer/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Developer developer)
        {
            await _service.UpdateDeveloper(id, developer);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
