using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface ICartRepository : IRepository<ICart>
    {
        Task<IEnumerable<ICart>> GetAllCartsAsync();
        Task<ICart> GetCartByIdAsync(int id);
        

    }
}
