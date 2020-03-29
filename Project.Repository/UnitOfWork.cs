using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.Repository.Common;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Project.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //protected IStoreContext _context;
        protected IStoreContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(IStoreContext context,IMapper mapper)
        {
            if (context ==null)
            {
                throw new ArgumentNullException("DbContext");
            }
            _context = context;
            _mapper = mapper;
            Developers = new DeveloperRepository(_context, _mapper);
            Carts = new CartRepository(_context, _mapper);
            Genres = new GameGenreRepository(_context, _mapper);
        }

        public IDeveloperRepository Developers { get; set; }
        public ICartRepository Carts { get; set; }

        public IGameGenreRepository Genres { get; set; }

        public virtual  Task<int> AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            
            try
            {
                var entry = _context.Instance.Entry(entity);
                if (entry.State != EntityState.Detached)
                {
                    entry.State = EntityState.Added;
                }
                else
                {
                    _context.Instance.Set<TEntity>().Add(entity);
                }
               
            }
            catch (Exception e)
            {

                 throw e;
            }
            return   Task.FromResult(1);
        }

        public async Task<int> CommitAsync()
        {
            int result = 0;
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await _context.Instance.SaveChangesAsync();
                scope.Complete();
            
            }

            return result;
                
        }

        public virtual Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                var entry = _context.Instance.Entry(entity);
                if (entry.State!=EntityState.Deleted)
                {
                    entry.State= EntityState.Deleted;
                }
                else
                {
                    _context.Instance.Set<TEntity>().Attach(entity);
                    _context.Instance.Set<TEntity>().Remove(entity);
                }

               // _context.Instance.Remove(entity);
                return Task.FromResult(1);                

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Task<int> DeleteAsync<TEntity>(int id) where TEntity : class
        {

            var entity = _context.Instance.Set<TEntity>().Find(id);
            if (entity==null)
            {
                return Task.FromResult(0);
            }
          return  DeleteAsync(entity);
        }

        public void Dispose()
        {
             _context.Dispose();
        }

        public  Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                var entry = _context.Instance.Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    _context.Instance.Set<TEntity>().Attach(entity);
                }

                _context.Instance.Entry(entity).State = EntityState.Modified;
                return Task.FromResult(1);
            }
            catch (Exception e)
            {

                throw e;
            }


        }
    }
}
