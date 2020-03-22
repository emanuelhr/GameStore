using Project.DAL.Entities;
using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IDeveloperRepository: IRepository<DeveloperEntity>
    {

        Task<IEnumerable<IDeveloper>> GetAllDevelopers(bool games=true);
        Task<IDeveloper> GetDeveloperById(int id,bool games = true);

    }
}
