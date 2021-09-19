using Asi.Domain.Common;
using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Asi.Model;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using IServiceType = Asi.Application.Interface.IServiceType;



namespace Asi.Application.Repositories
{
    internal class ServiceTypeRepository : IServiceType
    {
        private readonly IDbBusinessUnit _dbBusinessUnit;
        private readonly IMapper _mapper;

        public ServiceTypeRepository(IDbBusinessUnit dbBusinessUnit, IMapper mapper)
        {
            _dbBusinessUnit = dbBusinessUnit;
            _mapper = mapper;
        }
        public async Task Create(ServiceTypeModel model)
        {
            ServiceType item = _mapper.Map<ServiceType>(model);
            await _dbBusinessUnit.ServiceTypes.CreateAsync(item);
        }

        public async Task Delete(int id)
        {
            await _dbBusinessUnit.ServiceTypes.DeleteAsync(id);
        }

        public async Task<ServiceTypeModel> Get(ServiceTypeModel model)
        {
            ServiceType item = await _dbBusinessUnit.ServiceTypes.GetAsync(x => x.Title == model.Title);
            return _mapper.Map<ServiceTypeModel>(item);
        }

        public async Task<ServiceTypeModel> Get(int id)
        {
            ServiceType item = await _dbBusinessUnit.ServiceTypes.GetAsync(x => x.Id == id && x.IsDeleted == false);
            return _mapper.Map<ServiceTypeModel>(item);
        }


        public async Task<PagedList<ServiceTypeModel>> GetAll(int page, int pagesize)
        {
            PagedList<ServiceType> items = _dbBusinessUnit.ServiceTypes.PagedList(new PaginationFilter(page, pagesize), x => x.IsDeleted == false);
            return await Task.Run(() => _mapper.Map<PagedList<ServiceTypeModel>>(items));
        }

        public async Task<List<ServiceTypeModel>> GetAll(int index)
        {
            List<ServiceType> items = await _dbBusinessUnit.ServiceTypes.ListAsync(x => x.IsDeleted == false);
            return _mapper.Map<List<ServiceTypeModel>>(items);
        }

        public async Task<List<ServiceTypeModel>> GetDepartmnetServiceTypes(int departmentid)
        {
            List<ServiceType> serviceTypes = await _dbBusinessUnit.ServiceTypes.ListAsync(x => x.DepartmentId == departmentid && x.IsDeleted == false);
            return _mapper.Map<List<ServiceTypeModel>>(serviceTypes);
        }

        public async Task<PagedList<ServiceTypeModel>> Search(ServiceTypeModel model, int page, int pagesize)
        {
            PagedList<ServiceType> items = _dbBusinessUnit.ServiceTypes.PagedList(new PaginationFilter(page, pagesize), x => x.IsDeleted == false && x.Title == model.Title);
            return await Task.Run(() => _mapper.Map<PagedList<ServiceTypeModel>>(items));
        }

        public async Task<List<ServiceTypeModel>> Search(ServiceTypeModel model)
        {
            List<ServiceType> items = await _dbBusinessUnit.ServiceTypes.ListAsync(x => x.IsDeleted == false && x.Title == model.Title);
            return _mapper.Map<PagedList<ServiceTypeModel>>(items);
        }



        public async Task Update(ServiceTypeModel model)
        {
            ServiceType item = _mapper.Map<ServiceType>(model);
            await _dbBusinessUnit.ServiceTypes.UpdateAsync(item);
        }
    }
}
