using Asi.Domain.Entities;

namespace Asi.Domain.Interface
{
    public interface IDbBusinessUnit
    {

        IControl Controls { get; }
        IPayments Payments { get; }
        IReport Report { get; }
        IAuthentication Authentication { get; }
        IForm Forms { get; }
        IItem Items { get; }
        IDepartment Departments { get; }
        IPerson Persons { get; }
        IRepository<User> Users { get; }
        IRepository<UserRole> UserRoles { get; }
        IRepository<CertificateType> CertificateTypes { get; }
        IRepository<Province> Provinces { get; }
        IServiceType ServiceTypes { get; }
        ICertificate Certificates { get; }
        IRepository<UserItems> UserItems { get; }
        IFormGroup FormGroup { get; }
        IFormRow FormRows { get; }

    }
}
