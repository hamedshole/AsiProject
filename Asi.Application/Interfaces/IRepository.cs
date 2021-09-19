using Asi.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asi.Application.Interface
{
    public interface IRepository<T> where T : class
    {
        Task Create(T model);
        Task Update(T model);
        Task Delete(int id);
        Task<PagedList<T>> GetAll(int page, int pagesize);
        Task<PagedList<T>> Search(T model, int page, int pagesize);
        Task<List<T>> GetAll(int index = 0);
        Task<List<T>> Search(T model);

        Task<T> Get(T model);
        Task<T> Get(int id);
    }
}
