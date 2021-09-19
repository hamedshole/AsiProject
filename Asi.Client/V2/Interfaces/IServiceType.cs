using Asi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asi.Client.V2.Interfaces
{
    public interface IServiceType:IRepository<ServiceTypeModel>
    {
        Task<List<ServiceTypeModel>> GetDepartmnetServiceTypes(int departmentid);
    }
}
