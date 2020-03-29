using Project.DAL.Entities;
using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IGameGenreRepository : IRepository<GameGenreEntity>
    {

        Task<IEnumerable<IGameGenre>> GetAllGenres(bool games = true);
        Task<IGameGenre> GetGenreById(int id);

        Task<IGameGenre> GetLastGenreAsync();
        
    }
}
