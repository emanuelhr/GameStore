using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.DAL.Entities;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class GameGenreRepository : Repository<GameGenreEntity>, IGameGenreRepository
    {
        private readonly IMapper _mapper;

        public GameGenreRepository(IStoreContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }


        public async Task<IEnumerable<IGameGenre>> GetAllGenres(bool games = true)
        {
            var genresEntity=await _context.Genres.Include(g => g.GameGenre).ThenInclude(g=>g.GameEntity).ToListAsync();
            var gameGenre = _mapper.Map<IEnumerable<GameGenreEntity>, IEnumerable<GameGenre>>(genresEntity);
            return gameGenre;
        }

        public async Task<IGameGenre> GetGenreById(int id)
        {
            var genreEntity = await _context.Genres
                .Include(x => x.GameGenre)
               .ThenInclude(g => g.GameEntity)              
              // .ThenInclude(d=>d.Developer.ToString())
                .SingleOrDefaultAsync(x => x.Id == id);

            
            return _mapper.Map<GameGenreEntity, GameGenre>(genreEntity);

        }

        public async Task<IGameGenre> GetLastGenreAsync()
        {
            var lastGenreId = await _context.Genres.MaxAsync(x => x.Id);
            var lastGenre =await _context.Genres.FirstOrDefaultAsync(x=>x.Id==lastGenreId);
            return _mapper.Map<GameGenreEntity, GameGenre>(lastGenre);
        }
    }
}
