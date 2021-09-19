using Asi.Domain.Common;
using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Asi.Model;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using IPerson = Asi.Application.Interface.IPerson;

namespace Asi.Application.Repositories
{
    internal class PersonRepository : IPerson
    {
        private readonly IDbBusinessUnit _dbBusinessUnit;
        private readonly IMapper _mapper;

        public PersonRepository(IDbBusinessUnit dbBusinessUnit, IMapper mapper)
        {
            _dbBusinessUnit = dbBusinessUnit;
            _mapper = mapper;
        }
        public async Task Create(PersonModel model)
        {
            Person item = _mapper.Map<Person>(model);
            await _dbBusinessUnit.Persons.CreateAsync(item);
        }

        public async Task Delete(int id)
        {
            await _dbBusinessUnit.Persons.DeleteAsync(id);
        }

        public async Task<PersonModel> Get(PersonModel model)
        {
            Person item = await _dbBusinessUnit.Persons.GetAsync(x => x.Fullname == model.Fullname);
            return _mapper.Map<PersonModel>(item);
        }

        public async Task<PersonModel> Get(int id)
        {
            Person item = await _dbBusinessUnit.Persons.GetAsync(x => x.Id == id && x.IsDeleted == false);
            return _mapper.Map<PersonModel>(item);
        }


        public async Task<PagedList<PersonModel>> GetAll(int page, int pagesize)
        {
            PagedList<Person> items = _dbBusinessUnit.Persons.PagedList(new PaginationFilter(page, pagesize), x => x.IsDeleted == false);
            return await Task.Run(() => _mapper.Map<PagedList<PersonModel>>(items));
        }

        public async Task<List<PersonModel>> GetAll(int index)
        {
            List<Person> items = await _dbBusinessUnit.Persons.ListAsync(x => x.IsDeleted == false);
            return _mapper.Map<List<PersonModel>>(items);
        }


        public async Task<PagedList<PersonModel>> Search(PersonModel model, int page, int pagesize)
        {
            PagedList<Person> items = _dbBusinessUnit.Persons.PagedList(new PaginationFilter(page, pagesize), x => x.IsDeleted == false && x.Fullname == model.Fullname);
            return await Task.Run(() => _mapper.Map<PagedList<PersonModel>>(items));
        }

        public async Task<List<PersonModel>> Search(PersonModel model)
        {
            List<Person> items = await _dbBusinessUnit.Persons.ListAsync(x => x.IsDeleted == false && x.Fullname == model.Fullname);
            return _mapper.Map<PagedList<PersonModel>>(items);
        }
        public async Task Update(PersonModel model)
        {
            Person item = _mapper.Map<Person>(model);
            await _dbBusinessUnit.Persons.UpdateAsync(item);
        }
    }
}
