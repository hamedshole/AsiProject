using Asi.Domain.Common;
using Asi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asi.Application.Interface
{
    public interface IItem
    {
        Task Create(ItemModel model);
        Task Update(ItemModel model);
        Task Delete(int id);
        Task<PagedList<ItemModel>> GetAll(int page, int pagesize);
        Task<PagedList<ItemModel>> Search(ItemModel model, int page, int pagesize);
        Task<List<ItemModel>> GetAll(int index = 0);
        Task<List<ItemModel>> Search(ItemModel model);

        Task<ItemModel> Get(ItemModel model);
        Task<ItemModel> Get(int id);
        Task<List<ItemModel>> GetServieTypeItems(int servicetypeid);
        Task<List<ItemModel>> GetUserItems(int userId);
        Task<List<ItemModel>> GetUserItemsFilterByServiceType(int userId, int serviceTypeId);
    }
}
