using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IGameGenreService
    {
        Task<int> CreateGenreAsync(IGameGenre genre);
        Task<IEnumerable<IGameGenre>> GetGenresAsync();
        Task<IGameGenre> GetGenreByIdAsync(int id);

        Task<int> UpdateGenreAsync(int id);

        Task<IGameGenre> GetLastGenreAsync();
        Task<int> DeleteGenreAsync(int id);
    }
}
