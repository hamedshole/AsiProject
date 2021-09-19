using Asi.Domain.Entities;
using Asi.Domain.Interface;

namespace Asi.Business.Repositories
{
    internal class ProvincesRepository : Repository<Province>, IRepository<Province>
    {
            

        public ProvincesRepository(IAsiDbContext context) : base(context)
        {
         
        }

    }
}
