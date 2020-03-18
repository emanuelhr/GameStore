using Project.Model;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;
        private readonly IUnitOfWork _uow;

        public CartService(ICartRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }


        public async Task<int> CreateCart(ICart cart)
        {
          await  _uow.AddAsync(cart);
          return  await _uow.CommitAsync();
            
        }

        public async Task<IEnumerable<ICart>> GetAllCarts()
        {
            return await _repository.GetAllCartsAsync();


        }

        


    }
}
