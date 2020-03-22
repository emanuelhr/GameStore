using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IDeveloperService
    {
        Task<int> CreateDeveloper(IDeveloper developer);

        Task<IEnumerable<IDeveloper>> GetDevelopers(bool includeGames=true);

        Task<IDeveloper> GetDeveloperById(int id, bool includeGames = true);

        Task<int> UpdateDeveloper(int id, IDeveloper developer);
    }
}
