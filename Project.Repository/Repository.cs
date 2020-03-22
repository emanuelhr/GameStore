using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly IStoreContext _context;
        public Repository(IStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
        return   await Task.Run(()=> _context.Instance.Set<TEntity>().Where(predicate)) ;
            
        }

        public async  Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Instance.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Instance.Set<TEntity>().FindAsync(id);
        }

       
    }
}
