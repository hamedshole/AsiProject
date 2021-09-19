using Asi.Domain.Common;
using Asi.Client.Util.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asi.Client.Repositories
{
    public class Repository<T> : V1.Interfaces.IRepository<T>, V2.Interfaces.IRepository<T> where T : class, new()
    {
        private protected ICustomHttpClient _httpClient;
        private protected string _route;
        private readonly int _version;
       
        public Repository(ICustomHttpClient httpClient, string route,int version)
        {
            this._version = version;
            _httpClient = httpClient;
            this._route = route;
        }

        public void Create(T model)
        {
            _httpClient.SetRoute(_route);
            Task.Run(async () => await _httpClient.Post(model, version: _version));
        }

        public void Delete(int id)
        {
            _httpClient.SetRoute(_route);
            Task.Run(async () => await _httpClient.Delete(id, version: _version));
        }

        public T Get(T model)
        {
            _httpClient.SetRoute(_route);
            var res = Task.Run(async () => await _httpClient.Post<T, T>(model, version: _version)).Result;
            return res;
        }

        public T Get(string id)
        {
            _httpClient.SetRoute(_route);
            var res = Task.Run(async () => await _httpClient.Get<T>(id, version: _version)).Result;
            return res;
        }

        public PagedList<T> GetAll(int page, int pagesize)
        {
            _httpClient.SetRoute(_route);
            var res = Task.Run(async () => await _httpClient.Get<PagedList<T>>(string.Format("?PageNumber={0}&PageSize={1}", page, pagesize), version: _version)).Result;
            return res;
        }

        public List<T> GetAll(int index)
        {
            _httpClient.SetRoute(_route);
            var res = Task.Run(async () => await _httpClient.Get<List<T>>(version: _version)).Result;
            return res;
        }

        public PagedList<T> Search(T model, int page, int pagesize)
        {
            _httpClient.SetRoute(_route);
            var res = Task.Run(async () => await _httpClient.Post<T, PagedList<T>>(model, version: _version)).Result;
            return res;
        }

        public List<T> Search(T model)
        {
            _httpClient.SetRoute(_route);
            var res = Task.Run(async () => await _httpClient.Post<T, List<T>>(model, version: _version)).Result;
            return res;
        }

        public void Update(T model)
        {
            _httpClient.SetRoute(_route);
            Task.Run(async () => await _httpClient.Put(model, version: _version));
        }
    }
}
