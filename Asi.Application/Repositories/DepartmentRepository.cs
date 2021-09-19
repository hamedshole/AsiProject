using Asi.Domain.Common;
using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Asi.Model;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using IDepartment = Asi.Application.Interface.IDepartment;

namespace Asi.Application.Repositories
{
    internal class DepartmentRepository : IDepartment
    {
        private readonly IDbBusinessUnit _dbBusinessUnit;
        private readonly IMapper _mapper;

        public DepartmentRepository(IDbBusinessUnit dbBusinessUnit, IMapper mapper)
        {
            _dbBusinessUnit = dbBusinessUnit;
            _mapper = mapper;
        }
        public async Task Create(DepartmentModel model)
        {
            Department item = _mapper.Map<Department>(model);
            await _dbBusinessUnit.Departments.CreateAsync(item);
        }

        public async Task Delete(int id)
        {
            await _dbBusinessUnit.Departments.DeleteAsync(id);
        }

        public async Task<DepartmentModel> Get(DepartmentModel model)
        {
            Department item = await _dbBusinessUnit.Departments.GetAsync(x => x.Title == model.Title);
            return _mapper.Map<DepartmentModel>(item);
        }

        public async Task<DepartmentModel> Get(int id)
        {
            Department item = await _dbBusinessUnit.Departments.GetAsync(x => x.Id == id && x.IsDeleted == false);
            return _mapper.Map<DepartmentModel>(item);
        }


        public async Task<PagedList<DepartmentModel>> GetAll(int page, int pagesize)
        {
            PagedList<Department> items = _dbBusinessUnit.Departments.PagedList(new PaginationFilter(page, pagesize), x => x.IsDeleted == false);
            return await Task.Run(() => _mapper.Map<PagedList<DepartmentModel>>(items));
        }

        public async Task<List<DepartmentModel>> GetAll(int index)
        {
            List<Department> items = await _dbBusinessUnit.Departments.ListAsync(x => x.IsDeleted == false);
            return _mapper.Map<List<DepartmentModel>>(items);
        }


        public async Task<PagedList<DepartmentModel>> Search(DepartmentModel model, int page, int pagesize)
        {
            PagedList<Department> items = _dbBusinessUnit.Departments.PagedList(new PaginationFilter(page, pagesize), x => x.IsDeleted == false && x.Title == model.Title);
            return await Task.Run(() => _mapper.Map<PagedList<DepartmentModel>>(items));
        }

        public async Task<List<DepartmentModel>> Search(DepartmentModel model)
        {
            List<Department> items = await _dbBusinessUnit.Departments.ListAsync(x => x.IsDeleted == false && x.Title == model.Title);
            return _mapper.Map<PagedList<DepartmentModel>>(items);
        }
        public async Task Update(DepartmentModel model)
        {
            Department item = _mapper.Map<Department>(model);
            await _dbBusinessUnit.Departments.UpdateAsync(item);
        }
    }
}
