using Project.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service
{
    public interface ICartService
    {
        Task<int> CreateCart(ICart cart);
        Task<IEnumerable<ICart>> GetAllCarts();
        Task<ICart> GetCartById(int id);
    }
}