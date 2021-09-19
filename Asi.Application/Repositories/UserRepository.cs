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
    internal class UserRepository : IUser
    {
        private readonly IDbBusinessUnit _dbBusinessUnit;
        private readonly IMapper _mapper;

        public UserRepository(IDbBusinessUnit dbBusinessUnit, IMapper mapper)
        {
            _dbBusinessUnit = dbBusinessUnit;
            _mapper = mapper;
        }
        public async Task Create(UserModel model)
        {
            User item = _mapper.Map<User>(model);
            await _dbBusinessUnit.Users.CreateAsync(item);
        }

        public async Task Delete(int id)
        {
            await _dbBusinessUnit.Users.DeleteAsync(id);
        }

        public async Task<UserModel> Get(UserModel model)
        {
            User item = await _dbBusinessUnit.Users.GetAsync(x => x.Username == model.Username);
            return _mapper.Map<UserModel>(item);
        }

        public async Task<UserModel> Get(int id)
        {
            User item = await _dbBusinessUnit.Users.GetAsync(x => x.Id == id && x.IsDeleted == false);
            return _mapper.Map<UserModel>(item);
        }


        public async Task<PagedList<UserModel>> GetAll(int page, int pagesize)
        {
            PagedList<User> items = _dbBusinessUnit.Users.PagedList(new PaginationFilter(page, pagesize), x => x.IsDeleted == false);
            return await Task.Run(() => _mapper.Map<PagedList<UserModel>>(items));
        }

        public async Task<List<UserModel>> GetAll(int index)
        {
            List<User> items = await _dbBusinessUnit.Users.ListAsync(x => x.IsDeleted == false);
            return _mapper.Map<List<UserModel>>(items);
        }


        public async Task<PagedList<UserModel>> Search(UserModel model, int page, int pagesize)
        {
            PagedList<User> items = _dbBusinessUnit.Users.PagedList(new PaginationFilter(page, pagesize), x => x.IsDeleted == false && x.Username == model.Username);
            return await Task.Run(() => _mapper.Map<PagedList<UserModel>>(items));
        }

        public async Task<List<UserModel>> Search(UserModel model)
        {
            List<User> items = await _dbBusinessUnit.Users.ListAsync(x => x.IsDeleted == false && x.Username == model.Username);
            return _mapper.Map<PagedList<UserModel>>(items);
        }
        public async Task Update(UserModel model)
        {
            User item = _mapper.Map<User>(model);
            await _dbBusinessUnit.Users.UpdateAsync(item);
        }
    }
}
