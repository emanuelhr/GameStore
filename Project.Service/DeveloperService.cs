using AutoMapper;
using Project.DAL.Entities;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class DeveloperService : IDeveloperService
    {
       // private readonly IDeveloperRepository _repository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DeveloperService( IUnitOfWork uow, IMapper mapper)
        {
           // _repository = repository;
            _uow = uow;
            _mapper = mapper;
        }
        public Task<int> CreateDeveloper(IDeveloper developer)
        {
            var developerModel = _mapper.Map<IDeveloper, Developer>(developer);
           _uow.AddAsync(_mapper.Map<Developer, DeveloperEntity>(developerModel));
            return _uow.CommitAsync();
        }
        public Task<IEnumerable<IDeveloper>> GetDevelopers(bool includeGames = true)
        {
            return _uow.Developers.GetAllDevelopers();
        }

        public Task<IDeveloper> GetDeveloperById(int id, bool includeGames = true)
        {
            return _uow.Developers.GetDeveloperById(id);
        }

        public async Task<int> UpdateDeveloper(int id, IDeveloper developer)
        {
            var dev = await _uow.Developers.GetDeveloperById(id);
            if (dev!=null)
            {
                var model = _mapper.Map<IDeveloper, Developer>(developer);
               await _uow.UpdateAsync(_mapper.Map<Developer, DeveloperEntity>(model));
                return await _uow.CommitAsync();
            }

           return  await  Task.FromResult(0);
        }

        public Task<IDeveloper> GetLastDeveloperAsync()
        {
            return _uow.Developers.GetLastDeveloperAsync();
        }

        public Task<int> DeleteDeveloperAsync(int id)
        {
              _uow.DeleteAsync<DeveloperEntity>(id);
            return _uow.CommitAsync();

        }

        public Task<bool> DeveloperExists(int id)
        {
           return  _uow.Developers.DeveloperExist(id);
        }
    }
      
}
