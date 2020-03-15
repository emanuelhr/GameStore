using Project.DAL;
using Project.Model;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Project.Repository
{
    public class CartRepository : Repository<ICart>, ICartRepository
    {
        private readonly IMapper _mapper;

        public CartRepository(StoreContext context, IMapper mapper ) : base(context)
        {
            _mapper = mapper;
        }


        public IEnumerable<ICart> GetAllCarts()
        {
            return new List<ICart>(_mapper.Map<List<Cart>>(StoreContext.Carts.Include(p=>p.Games)).ToList()).AsEnumerable();
        }

        public ICart GetCartById(int id)
        {
            throw new NotImplementedException();
        }

        public StoreContext StoreContext
        {
            get { return Context as StoreContext; }
        }
    }
}
