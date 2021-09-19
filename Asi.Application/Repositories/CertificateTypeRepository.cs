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
    internal class CertificateTypeRepository : ICertificateType
    {
        private readonly IDbBusinessUnit _dbBusinessUnit;
        private readonly IMapper _mapper;

        public CertificateTypeRepository(IDbBusinessUnit dbBusinessUnit, IMapper mapper)
        {
            _dbBusinessUnit = dbBusinessUnit;
            _mapper = mapper;
        }
        public async Task Create(CertificateTypeModel model)
        {
            CertificateType item = _mapper.Map<CertificateType>(model);
            await _dbBusinessUnit.CertificateTypes.CreateAsync(item);
        }

        public async Task Delete(int id)
        {
            await _dbBusinessUnit.CertificateTypes.DeleteAsync(id);
        }

        public async Task<CertificateTypeModel> Get(CertificateTypeModel model)
        {
            CertificateType item = await _dbBusinessUnit.CertificateTypes.GetAsync(x => x.Title == model.Title);
            return _mapper.Map<CertificateTypeModel>(item);
        }

        public async Task<CertificateTypeModel> Get(int id)
        {
            CertificateType item = await _dbBusinessUnit.CertificateTypes.GetAsync(x => x.Id == id && x.IsDeleted == false);
            return _mapper.Map<CertificateTypeModel>(item);
        }


        public async Task<PagedList<CertificateTypeModel>> GetAll(int page, int pagesize)
        {
            PagedList<CertificateType> items = _dbBusinessUnit.CertificateTypes.PagedList(new PaginationFilter(page, pagesize), x => x.IsDeleted == false);
            return await Task.Run(() => _mapper.Map<PagedList<CertificateTypeModel>>(items));
        }

        public async Task<List<CertificateTypeModel>> GetAll(int index)
        {
            List<CertificateType> items = await _dbBusinessUnit.CertificateTypes.ListAsync(x => x.IsDeleted == false);
            return _mapper.Map<List<CertificateTypeModel>>(items);
        }


        public async Task<PagedList<CertificateTypeModel>> Search(CertificateTypeModel model, int page, int pagesize)
        {
            PagedList<CertificateType> items = _dbBusinessUnit.CertificateTypes.PagedList(new PaginationFilter(page, pagesize), x => x.IsDeleted == false && x.Title == model.Title);
            return await Task.Run(() => _mapper.Map<PagedList<CertificateTypeModel>>(items));
        }

        public async Task<List<CertificateTypeModel>> Search(CertificateTypeModel model)
        {
            List<CertificateType> items = await _dbBusinessUnit.CertificateTypes.ListAsync(x => x.IsDeleted == false && x.Title == model.Title);
            return _mapper.Map<PagedList<CertificateTypeModel>>(items);
        }
        public async Task Update(CertificateTypeModel model)
        {
            CertificateType item = _mapper.Map<CertificateType>(model);
            await _dbBusinessUnit.CertificateTypes.UpdateAsync(item);
        }
    }
}
