using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IDeveloperRepository: IRepository<IDeveloper>
    {

        IEnumerable<IDeveloper> GetAllDevelopers(bool games=true);
        IDeveloper GetDeveloperById(bool games = true);

    }
}
