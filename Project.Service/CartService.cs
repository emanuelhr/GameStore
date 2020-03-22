using AutoMapper;
using Project.DAL.Entities;
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
        private readonly IMapper _mapper;

        public CartService(ICartRepository repository, IUnitOfWork uow, IMapper mapper)
        {
            _repository = repository;
            _uow = uow;
            _mapper = mapper;
        }


        public  Task<int> CreateCart(ICart cart)
        {

            #region UOW
            var cartmodel = _mapper.Map<ICart, Cart>(cart);
            
            _uow.AddAsync(_mapper.Map<Cart, CartEntity>(cartmodel));
            _uow.CommitAsync();
            return Task.FromResult(1);
            #endregion

            #region MyRegion
            //var cartmodel = _mapper.Map<ICart, Cart>(cart);
            
            //_uow.AddAsync(_mapper.Map<Cart, CartEntity>(cartmodel));
            #endregion

        }

        public  Task<IEnumerable<ICart>> GetAllCarts()
        {
            return  _repository.GetAllCartsAsync();


        }

        public Task<ICart> GetCartById(int id)
        {

            return _repository.GetCartByIdAsync(id);
        }


        


    }
}
