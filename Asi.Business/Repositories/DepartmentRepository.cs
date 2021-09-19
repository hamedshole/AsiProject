using Asi.Domain.Entities;
using Asi.Domain.Interface;

namespace Asi.Business.Repositories
{
    internal class DepartmentRepository : Repository<Department>, IDepartment
    {

      

        public DepartmentRepository(IAsiDbContext context) : base(context)
        {
           
        }
    }
}
