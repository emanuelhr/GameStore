using AutoMapper;
using Project.DAL.Entities;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class GameGenreService : IGameGenreService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GameGenreService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<int> CreateGenreAsync(IGameGenre genre)
        {
            var model = _mapper.Map<IGameGenre, GameGenre>(genre);
            var entity = _mapper.Map<GameGenre, GameGenreEntity>(model);
            await _uow.AddAsync(entity);
            return await _uow.CommitAsync();
        }

        public Task<int> DeleteGenreAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IGameGenre> GetGenreByIdAsync(int id)
        {
            return await _uow.Genres.GetGenreById(id);
            
        }

        public  Task<IEnumerable<IGameGenre>> GetGenresAsync()
        {
            return  _uow.Genres.GetAllGenres();
        }

        public Task<IGameGenre> GetLastGenreAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateGenreAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
