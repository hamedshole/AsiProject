using Asi.Model;

namespace Asi.Client.V1.Interfaces
{
    public interface IV1BusinessUnit
    {
        IReport Report { get; }
        IAuthentication Authentication { get; }
        IRepository<DepartmentModel> Departments { get; }
        IItem Items { get; }
        IRepository<FormTemplateModel> ControlForms { get; }
        IRepository<CertificateTypeModel> CertificateTypes { get; }
        IRepository<ProvinceModel> Provinces { get; }
        IRepository<UserModel> Users { get; }
        IRepository<UserRoleModel> UserRoles { get; }
        IRepository<PersonModel> Persons { get; }
        IServiceType ServiceTypes { get; }
        IForm Form { get; }
        ICertificate Certificates { get; }
        ICertificateControl CertificateControls { get; }
        ICertificatePayment CertificatePayments { get; }

    }
}
