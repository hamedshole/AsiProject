using Asi.Application.Interface;
using Asi.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AsiMobile.ViewModels.Offline
{
    public  class CompanyViewModel
    {
       public ObservableCollection<CompanyModel> Companies { get; set; }
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        private IApplicationBusinessUnit _unit;
        public Command AddCompany { get; private set; }

        public CompanyViewModel()
        {
            AddCompany = new Command(AddCompanyMethod);
            _unit = App.ServiceProvider.GetService(typeof(IApplicationBusinessUnit)) as IApplicationBusinessUnit;
            Companies = new ObservableCollection<CompanyModel>();
            //List<CompanyModel> companyModels = Task.Run(async () => await _unit.co.GetAll(0)).Result;
           // companyModels.ForEach(x => Companies.Add(x));
           
            
        }

        private async void AddCompanyMethod(object obj)
        {
            CompanyModel companyModel = new CompanyModel
            {
                Name = this.Fullname,
                Address = this.Address,
                PhoneNumber = this.Address
            };
          //  await _unit.Companies.Create(companyModel);
        }
    }
}
