using Asi.Application.Interface;
using Asi.Mobile.LocalData.Interface;
using Asi.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AsiMobile.ViewModels.Offline
{
    public  class CompanyViewModel
    {
       public ObservableCollection<CompanyModel> Companies { get; set; }
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        ILocalData _localData;
        public Command AddCompany { get; private set; }

        public CompanyViewModel()
        {
            AddCompany = new Command(AddCompanyMethod);
            _localData = App.ServiceProvider.GetService(typeof(ILocalData)) as ILocalData;
            Companies = new ObservableCollection<CompanyModel>();
            List<CompanyModel> companyModels = _localData.Companies.GetAll();
            companyModels.ForEach(x => Companies.Add(x));
           
            
        }

        private  void AddCompanyMethod(object obj)
        {
            CompanyModel companyModel = new CompanyModel
            {
                Name = this.Fullname,
                Address = this.Address,
                PhoneNumber = this.Address
            };
            _localData.Companies.Create(companyModel);
        }
    }
}
