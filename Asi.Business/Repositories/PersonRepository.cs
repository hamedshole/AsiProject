using Asi.Domain.Entities;
using Asi.Domain.Interface;

namespace Asi.Business.Repositories
{
    internal class PersonRepository : Repository<Person>, IPerson
    {
       

        public PersonRepository(IAsiDbContext context) : base(context)
        {
            
        }

    }
}
