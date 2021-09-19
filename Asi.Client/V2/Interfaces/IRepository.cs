using Asi.Domain.Common;
using System.Collections.Generic;

namespace Asi.Client.V2.Interfaces
{
    public interface IRepository<T> where T:class
    {
        void Create(T model);
        void Update(T model);
        void Delete(int id);
        PagedList<T> GetAll(int page,int pagesize);
        PagedList<T> Search(T model,int page,int pagesize);
        List<T> GetAll(int index);
        List<T> Search(T model);

        T Get(T model);
        T Get(string id);
    }
}
