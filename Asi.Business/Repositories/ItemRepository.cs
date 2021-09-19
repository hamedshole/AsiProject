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
    internal class ItemRepository : Repository<Item>, IItem
    {
        private readonly IAsiDbContext _dbContext;

        public ItemRepository(IAsiDbContext context) : base(context)
        {
            _dbContext = context;
        }




        override public async Task<Item> GetAsync(Expression<Func<Item, bool>> expression)
        {
            Item itemDto = await _dbContext.Items.Include(x => x.ServiceType).Where(expression).FirstOrDefaultAsync();
            return itemDto;
            // return _mapper.Map<ItemModel>(itemDto);
        }



        public override PagedList<Item> PagedList(PaginationFilter pagination, Expression<Func<Item, bool>> expression)
        {
            PagedList<Item> itemDtos = _dbContext.Items.Include(x => x.ServiceType).ToPagedList(pagination);
            return itemDtos;
            //return _mapper.Map<PagedList<ItemModel>>(itemDtos);
        }

        public override async Task<List<Item>> ListAsync(Expression<Func<Item, bool>> expression)
        {
            List<Item> itemDtos = await _dbContext.Items.Include(x => x.ServiceType).Where(expression).ToListAsync();
            return itemDtos;
            //return _mapper.Map<PagedList<ItemModel>>(itemDtos);
        }



        async Task IRepository<Item>.UpdateAsync(Item entity)
        {
            _dbContext.Items.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
