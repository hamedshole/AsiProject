using Asi.Domain.Common;
using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Asi.Business.Repositories
{
    internal class UserItemsRepository : Repository<UserItems>
    {
        private readonly IAsiDbContext _dbContext;
        public UserItemsRepository(IAsiDbContext context) : base(context)
        {
            _dbContext = context;
        }
        public override async Task<List<UserItems>> ListAsync(Expression<Func<UserItems, bool>> expression)
        {
            return await _dbContext.UserItems.Include(x => x.Item).ThenInclude(x => x.ServiceType).Where(expression).ToListAsync();
        }
        public override PagedList<UserItems> PagedList(PaginationFilter pagination, Expression<Func<UserItems, bool>> expression)
        {
            return _dbContext.UserItems.Include(x => x.Item).ThenInclude(x => x.ServiceType).Where(expression).ToPagedList(pagination);
        }
    }
}
