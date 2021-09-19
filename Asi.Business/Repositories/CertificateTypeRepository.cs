using Asi.Domain.Entities;
using Asi.Domain.Interface;

namespace Asi.Business.Repositories
{
    internal class CertificateTypeRepository : Repository<CertificateType>, IRepository<CertificateType>
    {
       

        public CertificateTypeRepository(IAsiDbContext context) : base(context)
        {
           
        }
    }
}
