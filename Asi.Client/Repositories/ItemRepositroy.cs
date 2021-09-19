using Asi.Domain.Common;
using Asi.Client.Util.Interfaces;
using Asi.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IV1Item = Asi.Client.V1.Interfaces.IItem;
using IV2Item = Asi.Client.V2.Interfaces.IItem;


namespace Asi.Client.Repositories
{
    internal class ItemRepositroy : Repository<ItemModel>, IV1Item,IV2Item
    {
        private readonly int _version;
        public ItemRepositroy(ICustomHttpClient httpClient, string route,int version=1) : base(httpClient, route,version)
        {
            _version = version;
        }

        public async Task<List<ItemModel>> GetServieTypeItems(int servicetypeid)
        {
            try
            {
                _httpClient.SetRoute("items");
                return await _httpClient.Get<PagedList<ItemModel>>(string.Format("servicetype/{0}", servicetypeid),version:_version);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PagedList<ItemModel>> GetUserItems(int page, int pagesize, int userId)
        {
            try
            {
                _httpClient.SetRoute("items");
                return await _httpClient.Get<PagedList<ItemModel>>(string.Format("user={0}?PageNumber=1&PageSize=20", userId),version:_version);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PagedList<ItemModel>> GetUserItemsFilterByDepartment(int page, int pagesize, int userId, int departmentId)
        {
            try
            {
                _httpClient.SetRoute("items");
                return await _httpClient.Get<PagedList<ItemModel>>(string.Format("dep={0}&user={1}?PageNumber=1&PageSize=20", departmentId, userId),version:_version);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public  Task<PagedList<ItemModel>> SearchUserItems(int page, int pagesize, int userId, string text)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<ItemModel>> SearchUserItemsFilterByDepartment(int page, int pagesize, int userId, int departmentId, string text)
        {
            throw new NotImplementedException();
        }
    }
}
