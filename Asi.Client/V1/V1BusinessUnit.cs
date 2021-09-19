using Asi.Client.Repositories;
using Asi.Client.Util.Interfaces;
using Asi.Client.V1.Interfaces;
using Asi.Model;

namespace Asi.Client.V1
{
    internal    class V1BusinessUnit:IV1BusinessUnit
    {
        private readonly ICustomHttpClient _httpClient;
        private IReport _reportRepository;
        private ICertificateControl _certificateControlRepository;
        private ICertificatePayment _certificatePaymentsRepository;
        private IForm _formRepositroy;
        private IRepository<DepartmentModel> _departmentRepository;
        private IItem _itemRepository;
        private IRepository<FormTemplateModel> _controlFormRepository;
        private IRepository<CertificateTypeModel> _certificateTypesRepository;
        private IRepository<ProvinceModel> _provincesRepository;
        private IRepository<UserModel> _userRepository;
        private IRepository<UserRoleModel> _userRoleRepository;
        private IRepository<PersonModel> _personRepositroy;
        private IAuthentication _authenticationRepository;
        private ICertificate _certificateRepositroy;
        private IServiceType _serviceTypeRepository;
        private readonly int version;


        public V1BusinessUnit(ICustomHttpClient httpClient,int version=1)
        {
            this.version=version;
            _httpClient = httpClient;
        }

        IReport IV1BusinessUnit.Report
        {
            get
            {
                if (_reportRepository == null)
                {
                    _reportRepository = new ReportRepository(_httpClient, "report");
                }
                return _reportRepository;
            }
        }
        ICertificatePayment IV1BusinessUnit.CertificatePayments
        {
            get
            {
                if (_certificatePaymentsRepository == null)
                    _certificatePaymentsRepository = new CertificatePaymentsRepository(_httpClient, "certificatepayments",version);
                return _certificatePaymentsRepository;
            }
        }
        ICertificateControl IV1BusinessUnit.CertificateControls
        {
            get
            {
                if (_certificateControlRepository == null)
                    _certificateControlRepository = new CertificateControlRepository(_httpClient, "certificateControls", version);
                return _certificateControlRepository;
            }
        }

        IServiceType IV1BusinessUnit.ServiceTypes
        {
            get
            {
                if (_serviceTypeRepository == null)
                    _serviceTypeRepository = new ServiceTypeRepository(_httpClient, "servicetype",version);
                return _serviceTypeRepository;
            }
        }
        IRepository<DepartmentModel> IV1BusinessUnit.Departments
        {
            get
            {
                if (_departmentRepository == null)
                    _departmentRepository = new Repository<DepartmentModel>(_httpClient, "departments",version:version);
                return _departmentRepository;

            }
        }

        IItem IV1BusinessUnit.Items
        {
            get
            {
                if (_itemRepository == null)
                    _itemRepository = new ItemRepositroy(_httpClient, "items");
                return _itemRepository;
            }
        }
        IRepository<FormTemplateModel> IV1BusinessUnit.ControlForms
        {
            get
            {
                if (_controlFormRepository == null)
                    _controlFormRepository = new Repository<FormTemplateModel>(_httpClient, "controlForm",version);
                return _controlFormRepository;
            }
        }

      

        IRepository<CertificateTypeModel> IV1BusinessUnit.CertificateTypes
        {
            get
            {
                if (_certificateTypesRepository == null)
                    _certificateTypesRepository = new Repository<CertificateTypeModel>(_httpClient, "certificatetypes",version);
                return _certificateTypesRepository;
            }
        }

        IRepository<ProvinceModel> IV1BusinessUnit.Provinces
        {
            get
            {
                if (_provincesRepository == null)
                    _provincesRepository = new Repository<ProvinceModel>(_httpClient, "provinces",version);
                return _provincesRepository;
            }
        }



        IRepository<UserModel> IV1BusinessUnit.Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new Repository<UserModel>(_httpClient, "users",version);
                return _userRepository;
            }
        }


        IRepository<UserRoleModel> IV1BusinessUnit.UserRoles
        {
            get
            {
                if (_userRoleRepository == null)
                    _userRoleRepository = new Repository<UserRoleModel>(_httpClient, "userroles",version);
                return _userRoleRepository;
            }
        }

        IAuthentication IV1BusinessUnit.Authentication
        {
            get
            {
                if (_authenticationRepository == null)
                    _authenticationRepository = new AuthenticationRepositroy(_httpClient, "authentication",version);
                return _authenticationRepository;
            }
        }

        IForm IV1BusinessUnit.Form
        {
            get
            {
                if (_formRepositroy == null)
                    _formRepositroy = new FormRepository(_httpClient, "form",version);
                return _formRepositroy;
            }
        }

        ICertificate IV1BusinessUnit.Certificates
        {
            get
            {
                if (_certificateRepositroy == null)
                    _certificateRepositroy = new CertificateRepository(_httpClient, "certificate",version);
                return _certificateRepositroy;
            }
        }

        IRepository<PersonModel> IV1BusinessUnit.Persons
        {
            get
            {
                if (_personRepositroy == null)
                    _personRepositroy = new Repository<PersonModel>(_httpClient, "person",version);
                return _personRepositroy;
            }
        }
    }
}
