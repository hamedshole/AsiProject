using Asi.Domain.Entities;
using Asi.Domain.Interface;

namespace Asi.Business.Repositories
{
    internal class PaymentRepository : Repository<Payment>, IPayments
    {
       

        public PaymentRepository(IAsiDbContext context) : base(context)
        {
          
        }

    }
}
