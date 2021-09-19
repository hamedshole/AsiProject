using Asi.Domain.Common;
using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Asi.Business.Repositories
{
    internal class UserRepository : Repository<User>, IRepository<User>
    {
        private readonly IAsiDbContext _dbContext;

        public UserRepository(IAsiDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async override Task<User> GetAsync(Expression<Func<User, bool>> expression)
        {
            User userDto = await _dbContext.Users.Where(expression).Include(x => x.Person).Include(x => x.Role).FirstOrDefaultAsync();
            return userDto;
        }


        public override PagedList<User> PagedList(PaginationFilter pagination, Expression<Func<User, bool>> expression)
        {
            PagedList<User> userDtos = _dbContext.Users.Where(expression).Include(x => x.Person).ToPagedList(pagination);
            return userDtos;
        }

    }
}
