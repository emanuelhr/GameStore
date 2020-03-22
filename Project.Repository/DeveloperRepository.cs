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
        public async Task<IEnumerable<IDeveloper>> GetAllDevelopers(bool games = true)
        {
           return await  Task.Run(()=> _mapper.Map<List<Developer>>(_context.Developers.Include(x => x.Games)).ToList().AsEnumerable());
        }

        public async Task<IDeveloper> GetDeveloperById( int id,bool games = true)
        {
          var entity= _context.Developers.Find(id);
            _context.Instance.Entry(entity).State = EntityState.Detached;
                return await Task.Run(() => _mapper.Map<DeveloperEntity, IDeveloper>(entity));
           
        }
    }
}
