using Asi.Business.Repositories;
using Asi.Domain.Entities;
using Asi.Domain.Interface;

namespace Asi.Business
{
    internal class BusinessUnit : IDbBusinessUnit
    {

        private IControl _controlRepositroy;
        private IPayments _paymentRepository;
        private IAuthentication _authenticationRepository;
        private IDepartment _departmentRepository;
        private IPerson _personRepository;
        private IRepository<User> _userRepository;
        private IRepository<UserRole> _userRoleRepository;
        private IServiceType _serviceTypeRepository;
        private IItem _itemRepository;
        private IForm _formRepositroy;
        private IRepository<CertificateType> _certTypeRepository;
        private IRepository<Province> _provincesRepository;
        private ICertificate _certificateRepositroy;
        private IReport _reportRepository;
        private IRepository<UserItems> _userItemsRepository;
        private IFormGroup _formGroupRepository;
        private IFormRow _formRowRepositroy;
        private readonly IAsiDbContext _dbContext;


        public BusinessUnit(IAsiDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        IRepository<UserItems> IDbBusinessUnit.UserItems => _userItemsRepository ??(_userItemsRepository= new UserItemsRepository(_dbContext));


        IControl IDbBusinessUnit.Controls => _controlRepositroy ??(_controlRepositroy= new CertificateControlRepository(_dbContext));


        IPayments IDbBusinessUnit.Payments => _paymentRepository ??(_paymentRepository= new PaymentRepository(_dbContext));


        IAuthentication IDbBusinessUnit.Authentication => _authenticationRepository ??(_authenticationRepository= new AuthenticationRepository(_dbContext));


        IItem IDbBusinessUnit.Items => _itemRepository ??(_itemRepository= new ItemRepository(_dbContext));


        IPerson IDbBusinessUnit.Persons => _personRepository ??(_personRepository= new PersonRepository(_dbContext));


        IRepository<User> IDbBusinessUnit.Users => _userRepository ??(_userRepository= new UserRepository(_dbContext));


        IRepository<UserRole> IDbBusinessUnit.UserRoles => _userRoleRepository ??(_userRoleRepository= new UserRoleRepository(_dbContext));


        IDepartment IDbBusinessUnit.Departments => _departmentRepository ??(_departmentRepository= new DepartmentRepository(_dbContext));


        IRepository<CertificateType> IDbBusinessUnit.CertificateTypes => _certTypeRepository ??(_certTypeRepository= new CertificateTypeRepository(_dbContext));

        IRepository<Province> IDbBusinessUnit.Provinces => _provincesRepository ??(_provincesRepository= new ProvincesRepository(_dbContext));


        IForm IDbBusinessUnit.Forms => _formRepositroy ??(_formRepositroy= new FormRepository(_dbContext));


        ICertificate IDbBusinessUnit.Certificates => _certificateRepositroy ??(_certificateRepositroy= new CertificateRepository(_dbContext));

        IReport IDbBusinessUnit.Report => _reportRepository ??(_reportRepository= new ReportRepository(_dbContext));

        IServiceType IDbBusinessUnit.ServiceTypes => _serviceTypeRepository ??(_serviceTypeRepository= new ServiceTypeRepository(_dbContext));

        IFormGroup IDbBusinessUnit.FormGroup => _formGroupRepository ??(_formGroupRepository= new FormGroupRepository(_dbContext));


        IFormRow IDbBusinessUnit.FormRows => _formRowRepositroy ??(_formRowRepositroy= new FormRowRepository(_dbContext));

    }
}
