using Asi.Domain.Entities;
using Asi.Domain.Interface;

namespace Asi.Business.Repositories
{
    internal class ServiceTypeRepository : Repository<ServiceType>, IServiceType
    {

     

        public ServiceTypeRepository(IAsiDbContext context) : base(context)
        {
            
        }

    }
}
