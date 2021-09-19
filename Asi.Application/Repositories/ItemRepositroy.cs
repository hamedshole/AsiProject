using Asi.Domain.Common;
using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Asi.Model;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IItem = Asi.Application.Interface.IItem;


namespace Asi.Application.Repositories
{
    internal class ItemRepositroy : IItem
    {
        private readonly IDbBusinessUnit _dbBusinessUnit;
        private readonly IMapper _mapper;

        public ItemRepositroy(IDbBusinessUnit dbBusinessUnit, IMapper mapper)
        {
            _dbBusinessUnit = dbBusinessUnit;
            _mapper = mapper;
        }

        public async Task Create(ItemModel model)
        {
         //   model = JsonConvert.DeserializeObject<ItemModel>(System.IO.File.ReadAllText(@"D:\بالابر تسمه ای.txt"));
            Item item = _mapper.Map<Item>(model);
            await _dbBusinessUnit.Items.CreateAsync(item);
        }

        public async Task Delete(int id)
        {
            await _dbBusinessUnit.Items.DeleteAsync(id);
        }

        public async Task<ItemModel> Get(ItemModel model)
        {
            Item item = await _dbBusinessUnit.Items.GetAsync(x => x.Title == model.Title);
            return _mapper.Map<ItemModel>(item);
        }

        public async Task<ItemModel> Get(int id)
        {
            Item item = await _dbBusinessUnit.Items.GetAsync(x => x.Id == id && x.IsDeleted == false);
            return _mapper.Map<ItemModel>(item);
        }

        public async Task<PagedList<ItemModel>> GetAll(int page, int pagesize)
        {
            PagedList<Item> items = _dbBusinessUnit.Items.PagedList(new PaginationFilter(page, pagesize), x => x.IsDeleted == false);
            return await Task.Run(() => _mapper.Map<PagedList<ItemModel>>(items));
        }

        public async Task<List<ItemModel>> GetAll(int index)
        {
            List<Item> items = await _dbBusinessUnit.Items.ListAsync(x => x.IsDeleted == false);
            return _mapper.Map<List<ItemModel>>(items);
        }

        public async Task<List<ItemModel>> GetServieTypeItems(int servicetypeid)
        {
            List<Item> items = await _dbBusinessUnit.Items.ListAsync(x => x.ServiceTypeId == servicetypeid);
            return _mapper.Map<List<ItemModel>>(items);
        }



        public async Task<List<ItemModel>> GetUserItems(int userId)
        {
            List<Item> items = (await _dbBusinessUnit.UserItems.ListAsync(x => x.UserId == userId)).Select(x => x.Item).Where(x => x.IsDeleted == false).ToList();
            return _mapper.Map<List<ItemModel>>(items);
        }


        public async Task<List<ItemModel>> GetUserItemsFilterByServiceType(int userId, int serviceTypeId)
        {
            List<Item> items = (await _dbBusinessUnit.UserItems.ListAsync(x => x.UserId == userId)).Select(x => x.Item).Where(x => x.IsDeleted == false && x.ServiceTypeId == serviceTypeId).ToList();
            return _mapper.Map<List<ItemModel>>(items);
        }

        public async Task<PagedList<ItemModel>> Search(ItemModel model, int page, int pagesize)
        {
            PagedList<Item> items = _dbBusinessUnit.Items.PagedList(new PaginationFilter(page, pagesize), x => x.IsDeleted == false && x.Title == model.Title);
            return await Task.Run(() => _mapper.Map<PagedList<ItemModel>>(items));
        }

        public async Task<List<ItemModel>> Search(ItemModel model)
        {
            List<Item> items = await _dbBusinessUnit.Items.ListAsync(x => x.IsDeleted == false && x.Title == model.Title);
            return _mapper.Map<PagedList<ItemModel>>(items);
        }



        public async Task Update(ItemModel model)
        {
            Item item = _mapper.Map<Item>(model);
            await _dbBusinessUnit.Items.UpdateAsync(item);
        }
    }
}
