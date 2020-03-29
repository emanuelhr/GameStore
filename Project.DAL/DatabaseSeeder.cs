using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class DatabaseSeeder
    {
        private readonly StoreContext _context;

        public DatabaseSeeder(StoreContext context)
        {
            _context = context;
        }


        public void InitaliseSeeder()

        {


            _context.Database.EnsureCreated();
            if (_context.Developers.Any())
            {
                return;
            }


            var developers = new List<DeveloperEntity>();
            developers.Add(new DeveloperEntity()

            { Headquarters = "Canada",
                Name = "EA"
            }
                );
            developers.Add(new DeveloperEntity()

            {
                Headquarters = "Italy",
                Name = "Square Enix"
            }
               );


            var gameGenres = new List<GameGenreEntity>();
            gameGenres.Add(new GameGenreEntity() { Genre = "Action" });
            gameGenres.Add(new GameGenreEntity() { Genre = "Adventure" });
            gameGenres.Add(new GameGenreEntity() { Genre = "RPG" });
            gameGenres.Add(new GameGenreEntity() { Genre = "Sports" });
            


            var games = new List<GameEntity>();
            games.Add(new GameEntity() { Name = "Final Fantasy", Developer = developers[0], Price = 20, ReleaseDate = DateTime.Now });
            games.Add(new GameEntity() { Name = "Final Fantasy 15", Developer = developers[1], Price = 15, ReleaseDate = DateTime.Now });
            


            foreach (var developer in developers)
            {
                _context.Add(developer);
            }
            _context.SaveChanges();
            foreach (var gamegenre in gameGenres)
            {
                _context.Add(gamegenre);
            }

            _context.SaveChanges();

            foreach (var game in games)
            {
                _context.Add(game);
            }
            _context.SaveChanges();

        }



    }
}
