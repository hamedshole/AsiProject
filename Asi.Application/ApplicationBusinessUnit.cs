using Asi.Application.Interface;
using Asi.Application.Repositories;
using AutoMapper;
using IDbBusinessUnit = Asi.Domain.Interface.IDbBusinessUnit;

namespace Asi.Application
{
    internal class ApplicationBusinessUnit : IApplicationBusinessUnit
    {

        private IReport _reportRepository;
        private ICertificateControl _certificateControlRepository;
        private ICertificatePayment _certificatePaymentsRepository;
        private IForm _formRepositroy;
        private IDepartment _departmentRepository;
        private IItem _itemRepository;
        private IForm _controlFormRepository;
        private ICertificateType _certificateTypesRepository;
        private IProvince _provincesRepository;
        private IUser _userRepository;
        private IUserRole _userRoleRepository;
        private IPerson _personRepositroy;
        private IAuthentication _authenticationRepository;
        private ICertificate _certificateRepositroy;
        private IServiceType _serviceTypeRepository;



        private readonly IMapper _mapper;
        private readonly IDbBusinessUnit _dbBusinessUnit;
        public ApplicationBusinessUnit(IDbBusinessUnit dbBusinessUnit, IMapper mapper)
        {
            _dbBusinessUnit = dbBusinessUnit;
            _mapper = mapper;
        }
        IReport IApplicationBusinessUnit.Report
        {
            get
            {
                if (_reportRepository == null)
                {
                    _reportRepository = new ReportRepository(_dbBusinessUnit, _mapper);
                }
                return _reportRepository;
            }
        }
        ICertificatePayment IApplicationBusinessUnit.CertificatePayments
        {
            get
            {
                if (_certificatePaymentsRepository == null)
                    _certificatePaymentsRepository = new CertificatePaymentsRepository(_dbBusinessUnit, _mapper);
                return _certificatePaymentsRepository;
            }
        }
        ICertificateControl IApplicationBusinessUnit.CertificateControls
        {
            get
            {
                if (_certificateControlRepository == null)
                    _certificateControlRepository = new CertificateControlRepository(_dbBusinessUnit, _mapper);
                return _certificateControlRepository;
            }
        }

        IServiceType IApplicationBusinessUnit.ServiceTypes
        {
            get
            {
                if (_serviceTypeRepository == null)
                    _serviceTypeRepository = new ServiceTypeRepository(_dbBusinessUnit, _mapper);
                return _serviceTypeRepository;
            }
        }
        IDepartment IApplicationBusinessUnit.Departments
        {
            get
            {
                if (_departmentRepository == null)
                    _departmentRepository = new DepartmentRepository(_dbBusinessUnit, _mapper);
                return _departmentRepository;

            }
        }

        IItem IApplicationBusinessUnit.Items
        {
            get
            {
                if (_itemRepository == null)
                    _itemRepository = new ItemRepositroy(_dbBusinessUnit, _mapper);
                return _itemRepository;
            }
        }
        IForm IApplicationBusinessUnit.ControlForms
        {
            get
            {
                if (_controlFormRepository == null)
                    _controlFormRepository = new FormRepository(_dbBusinessUnit, _mapper);
                return _controlFormRepository;
            }
        }



        ICertificateType IApplicationBusinessUnit.CertificateTypes
        {
            get
            {
                if (_certificateTypesRepository == null)
                    _certificateTypesRepository = new CertificateTypeRepository(_dbBusinessUnit, _mapper);
                return _certificateTypesRepository;
            }
        }

        IProvince IApplicationBusinessUnit.Provinces
        {
            get
            {
                if (_provincesRepository == null)
                    _provincesRepository = new ProvinceRepository(_dbBusinessUnit, _mapper);
                return _provincesRepository;
            }
        }



        IUser IApplicationBusinessUnit.Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_dbBusinessUnit, _mapper);
                return _userRepository;
            }
        }


        IUserRole IApplicationBusinessUnit.UserRoles
        {
            get
            {
                if (_userRoleRepository == null)
                    _userRoleRepository = new UserRoleRepository(_dbBusinessUnit, _mapper);
                return _userRoleRepository;
            }
        }

        IAuthentication IApplicationBusinessUnit.Authentication
        {
            get
            {
                if (_authenticationRepository == null)
                    _authenticationRepository = new AuthenticationRepositroy(_dbBusinessUnit, _mapper);
                return _authenticationRepository;
            }
        }


        ICertificate IApplicationBusinessUnit.Certificates
        {
            get
            {
                if (_certificateRepositroy == null)
                    _certificateRepositroy = new CertificateRepository(_dbBusinessUnit, _mapper);
                return _certificateRepositroy;
            }
        }

        IPerson IApplicationBusinessUnit.Persons
        {
            get
            {
                if (_personRepositroy == null)
                    _personRepositroy = new PersonRepository(_dbBusinessUnit, _mapper);
                return _personRepositroy;
            }
        }
        IForm IApplicationBusinessUnit.Form
        {
            get
            {
                if (_formRepositroy == null)
                    _formRepositroy = new FormRepository(_dbBusinessUnit, _mapper);
                return _formRepositroy;
            }
        }
    }
}
