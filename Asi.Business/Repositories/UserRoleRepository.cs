using Asi.Domain.Entities;
using Asi.Domain.Interface;

namespace Asi.Business.Repositories
{
    internal class UserRoleRepository : Repository<UserRole>, IRepository<UserRole>
    {
    

        public UserRoleRepository(IAsiDbContext context) : base(context)
        {
           
        }


    }
}
