using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Model;
using Project.Model.Common;
using Project.Service;

namespace Project.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;
        private readonly ILogger<ICartService> _logger;

        public CartController(ICartService service, ILogger<ICartService> logger)
        {
            _service = service;
            _logger = logger;
        }
        // GET: api/Cart
        [HttpGet]
        public async Task<IEnumerable<ICart>> Get()
        {

            return await _service.GetAllCarts();
        }

        // GET: api/Cart/5
        [HttpGet("{id}", Name = "Get_cart")]
        public async Task<ICart> Get(int id)
        {
            return await _service.GetCartById(id);
        }

        // POST: api/Cart
        [HttpPost]
        public async Task Post()
        {

            var developer = new Developer();
            developer.Headquarters = "sdasda";
            developer.Name = "EA";
            

            var genre = new GameGenre();
            genre.Genre = "Action";
            var game = new Game();
            game.Name = "Something";
            game.Price = 10;
            game.ReleaseDate = DateTime.Now;

            game.Genre = new List<IGameGenre>();
            game.Genre.Add(genre);
            developer.Games = new List<IGame>();
            developer.Games.Add(game);
            game.Developer = developer;
            genre.Games = new List<IGame>();
            genre.Games.Add(game);

            
            var cart = new Cart();
            
            cart.Games = new List<IGame>();






            cart.Games.Add(game);
            _logger.LogInformation("Info");

            await _service.CreateCart(cart);
            

        }

        // PUT: api/Cart/5
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
