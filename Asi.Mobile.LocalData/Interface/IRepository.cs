using Asi.Model;
using System.Collections.Generic;

namespace Asi.Mobile.LocalData.Interface
{
    public interface IRepository<TModel> where TModel:BaseModel
    {
        void Create(TModel model);
        void Update(TModel model);
        void Delete(TModel model);
        List<TModel> GetAll();

    }
}
