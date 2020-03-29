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
    public class GenresController : ControllerBase
        
       
    {
        private readonly IGameGenreService _service;
        private readonly ILogger<IGameGenreService> _logger;

        public GenresController(IGameGenreService service, ILogger<IGameGenreService> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IGameGenre>>> Get()
        {
            
            try
            {
                return Ok(await _service.GetGenresAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to retrieve genres : {ex}");
                return BadRequest("Failed to retrieve genres");
            }
        }

        // GET: api/Genres/5
        [HttpGet("{id}", Name = "Get_genre")]
        public async Task<ActionResult<IGameGenre>> Get(int id)
        {
            try
            {
                return Ok(await _service.GetGenreByIdAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to retrieve genres : {ex}");

            }
            return BadRequest("Failed to retrieve genres");
        }

        // POST: api/Genres
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GameGenre genre)
        {
            try
            {

                if (await _service.CreateGenreAsync(genre) == 1)
                {
                    var createdGenre = await _service.GetLastGenreAsync();
                    return Created("api/genre", createdGenre);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create genre : {ex}");

            }
            return BadRequest("Failed to create genre");

        }

        // PUT: api/Genres/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
