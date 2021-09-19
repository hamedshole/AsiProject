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
    internal class UserRoleRepository : IUserRole
    {
        private readonly IDbBusinessUnit _dbBusinessUnit;
        private readonly IMapper _mapper;

        public UserRoleRepository(IDbBusinessUnit dbBusinessUnit, IMapper mapper)
        {
            _dbBusinessUnit = dbBusinessUnit;
            _mapper = mapper;
        }
        public async Task Create(UserRoleModel model)
        {
            UserRole item = _mapper.Map<UserRole>(model);
            await _dbBusinessUnit.UserRoles.CreateAsync(item);
        }

        public async Task Delete(int id)
        {
            await _dbBusinessUnit.UserRoles.DeleteAsync(id);
        }

        public async Task<UserRoleModel> Get(UserRoleModel model)
        {
            UserRole item = await _dbBusinessUnit.UserRoles.GetAsync(x => x.Title == model.Title);
            return _mapper.Map<UserRoleModel>(item);
        }

        public async Task<UserRoleModel> Get(int id)
        {
            UserRole item = await _dbBusinessUnit.UserRoles.GetAsync(x => x.Id == id && x.IsDeleted == false);
            return _mapper.Map<UserRoleModel>(item);
        }


        public async Task<PagedList<UserRoleModel>> GetAll(int page, int pagesize)
        {
            PagedList<UserRole> items = _dbBusinessUnit.UserRoles.PagedList(new PaginationFilter(page, pagesize), x => x.IsDeleted == false);
            return await Task.Run(() => _mapper.Map<PagedList<UserRoleModel>>(items));
        }

        public async Task<List<UserRoleModel>> GetAll(int index)
        {
            List<UserRole> items = await _dbBusinessUnit.UserRoles.ListAsync(x => x.IsDeleted == false);
            return _mapper.Map<List<UserRoleModel>>(items);
        }


        public async Task<PagedList<UserRoleModel>> Search(UserRoleModel model, int page, int pagesize)
        {
            PagedList<UserRole> items = _dbBusinessUnit.UserRoles.PagedList(new PaginationFilter(page, pagesize), x => x.IsDeleted == false && x.Title == model.Title);
            return await Task.Run(() => _mapper.Map<PagedList<UserRoleModel>>(items));
        }

        public async Task<List<UserRoleModel>> Search(UserRoleModel model)
        {
            List<UserRole> items = await _dbBusinessUnit.UserRoles.ListAsync(x => x.IsDeleted == false && x.Title == model.Title);
            return _mapper.Map<PagedList<UserRoleModel>>(items);
        }
        public async Task Update(UserRoleModel model)
        {
            UserRole item = _mapper.Map<UserRole>(model);
            await _dbBusinessUnit.UserRoles.UpdateAsync(item);
        }
    }
}
