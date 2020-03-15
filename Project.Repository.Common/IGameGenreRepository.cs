using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IGameGenreRepository : IRepository<IGameGenre>
    {

        IEnumerable<IGameGenre> GetAllGenres(bool games = true);
        IGameGenre GetGenreById(int id);
        
    }
}
