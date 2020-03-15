using Project.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IGameRepository : IRepository<IGame>
    {

        IEnumerable<IGame> GetAllGames(bool genre=true);
        IGame GetGameById(int id);
        
    }
}
