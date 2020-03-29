using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.DAL.Entities;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class DeveloperRepository : Repository<DeveloperEntity>, IDeveloperRepository
    {
      //  private readonly IStoreContext _context;
        private readonly IMapper _mapper;

        public DeveloperRepository(IStoreContext context,IMapper mapper) : base(context)
        {
         //   _context = context;
            _mapper = mapper;
        }

        public Task<bool> DeveloperExist(int id)
        {
            if (_context.Developers.Find(id)==null)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public async Task<IEnumerable<IDeveloper>> GetAllDevelopers(bool games = true)
        {
            var entity=await  _context.Developers.Include(x => x.Games).ToListAsync();
           return  _mapper.Map<IEnumerable<DeveloperEntity>,IEnumerable<Developer>>(entity.AsEnumerable());
        }

        public async Task<IDeveloper> GetDeveloperById( int id,bool games = true)
        {
          var entity=await _context.Developers.FindAsync(id);
         
            _context.Instance.Entry(entity).State = EntityState.Detached;
                return _mapper.Map<DeveloperEntity, Developer>(entity);
           
        }

        public async Task<IDeveloper> GetLastDeveloperAsync()
        {
            var lastDeveloperId = await _context.Developers.MaxAsync(i => i.Id);
            var developer = await _context.Developers.FirstOrDefaultAsync(x=>x.Id==lastDeveloperId);
            return _mapper.Map< DeveloperEntity, Developer > (developer);
        }
    }
}
