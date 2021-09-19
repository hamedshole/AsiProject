using Asi.Domain.Common;
using Asi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asi.Client.V2.Interfaces
{
    public interface IItem:IRepository<ItemModel>
    {
        Task<List<ItemModel>> GetServieTypeItems(int servicetypeid); 
        Task<PagedList<ItemModel>> GetUserItems(int page, int pagesize, int userId);
        Task<PagedList<ItemModel>> SearchUserItemsFilterByDepartment(int page, int pagesize, int userId, int departmentId, string text);
        Task<PagedList<ItemModel>> GetUserItemsFilterByDepartment(int page, int pagesize, int userId, int departmentId);
        Task<PagedList<ItemModel>> SearchUserItems(int page, int pagesize, int userId, string text);
    }
}
