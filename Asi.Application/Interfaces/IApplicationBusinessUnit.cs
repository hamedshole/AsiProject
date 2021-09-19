namespace Asi.Application.Interface
{
    public interface IApplicationBusinessUnit
    {
        IReport Report { get; }
        IAuthentication Authentication { get; }
        IDepartment Departments { get; }
        IItem Items { get; }
        IForm ControlForms { get; }
        ICertificateType CertificateTypes { get; }
        IProvince Provinces { get; }
        IUser Users { get; }
        IUserRole UserRoles { get; }
        IPerson Persons { get; }
        IServiceType ServiceTypes { get; }
        IForm Form { get; }
        ICertificate Certificates { get; }
        ICertificateControl CertificateControls { get; }
        ICertificatePayment CertificatePayments { get; }
    }
}
