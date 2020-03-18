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
       
        private readonly StoreContext _context;
        private readonly IMapper _mapper;

        public CartRepository(StoreContext context, IMapper mapper ) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ICart>> GetAllCartsAsync()
        {
            return await Task.Run(()=> new List<ICart>(_mapper.Map<List<Cart>>(_context.Carts.Include(p => p.Games)).ToList()).AsEnumerable()) ;
        
        }

        public async  Task<ICart> GetCartByIdAsync(int id)
        {
            return  _mapper.Map<Cart>(await _context.Carts.FindAsync(id));
        }

       

        //public StoreContext StoreContext
        //{
        //    get { return Context as StoreContext; }
        //}
    }
}
