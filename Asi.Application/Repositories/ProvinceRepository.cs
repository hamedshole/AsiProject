using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Asi.Model;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asi.Application.Repositories
{
    internal class ProvinceRepository : IProvince
    {
        private readonly IDbBusinessUnit _dbBusinessUnit;
        private readonly IMapper _mapper;

        public ProvinceRepository(IDbBusinessUnit dbBusinessUnit, IMapper mapper)
        {
            _dbBusinessUnit = dbBusinessUnit;
            _mapper = mapper;
        }
        public async Task Create(ProvinceModel model)
        {
            Province item = _mapper.Map<Province>(model);
            await _dbBusinessUnit.Provinces.CreateAsync(item);
        }

        public async Task Delete(int id)
        {
            await _dbBusinessUnit.Provinces.DeleteAsync(id);
        }

        public async Task<ProvinceModel> Get(ProvinceModel model)
        {
            Province item = await _dbBusinessUnit.Provinces.GetAsync(x => x.Title == model.Title);
            return _mapper.Map<ProvinceModel>(item);
        }

        public async Task<ProvinceModel> Get(int id)
        {
            Province item = await _dbBusinessUnit.Provinces.GetAsync(x => x.Id == id && x.IsDeleted == false);
            return _mapper.Map<ProvinceModel>(item);
        }


        public async Task<PagedList<ProvinceModel>> GetAll(int page, int pagesize)
        {
            PagedList<Province> items = _dbBusinessUnit.Provinces.PagedList(new PaginationFilter(page, pagesize), x => x.IsDeleted == false);
            return await Task.Run(() => _mapper.Map<PagedList<ProvinceModel>>(items));
        }

        public async Task<List<ProvinceModel>> GetAll(int index)
        {
            List<Province> items = await _dbBusinessUnit.Provinces.ListAsync(x => x.IsDeleted == false);
            return _mapper.Map<List<ProvinceModel>>(items);
        }


        public async Task<PagedList<ProvinceModel>> Search(ProvinceModel model, int page, int pagesize)
        {
            PagedList<Province> items = _dbBusinessUnit.Provinces.PagedList(new PaginationFilter(page, pagesize), x => x.IsDeleted == false && x.Title == model.Title);
            return await Task.Run(() => _mapper.Map<PagedList<ProvinceModel>>(items));
        }

        public async Task<List<ProvinceModel>> Search(ProvinceModel model)
        {
            List<Province> items = await _dbBusinessUnit.Provinces.ListAsync(x => x.IsDeleted == false && x.Title == model.Title);
            return _mapper.Map<PagedList<ProvinceModel>>(items);
        }
        public async Task Update(ProvinceModel model)
        {
            Province item = _mapper.Map<Province>(model);
            await _dbBusinessUnit.Provinces.UpdateAsync(item);
        }
    }
}
