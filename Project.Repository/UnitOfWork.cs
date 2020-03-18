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
        private readonly StoreContext _context;
       

        public UnitOfWork(StoreContext context)
        {
            _context = context;
            
        }


        public virtual  Task<int> AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                 _context.AddAsync(entity);
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
                result = await _context.SaveChangesAsync();
                scope.Complete();
            
            }

            return result;
                
        }

        public virtual Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                _context.Remove(entity);
                return Task.FromResult(1);                

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Task<int> DeleteAsync<TEntity>(int id) where TEntity : class
        {
            var entity = _context.Set<TEntity>().Find(id);
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
                _context.Entry(entity).State = EntityState.Modified;
                return Task.FromResult(1);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
