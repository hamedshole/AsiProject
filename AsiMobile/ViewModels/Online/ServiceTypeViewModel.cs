using Asi.Client.V2.Interfaces;
using Asi.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AsiMobile.ViewModels.Online
{
   public class ServiceTypeViewModel
    {
        public Command<ServiceTypeModel> GoToItems { get; private set; }
        public ObservableCollection<ServiceTypeModel> ServiceTypes{ get; set; }
        private IV2BusinessUnit _unit { get;  set; }
        public ServiceTypeViewModel(int departmentid)
        {
            ServiceTypes = new ObservableCollection<ServiceTypeModel>();
            GoToItems = new Command<ServiceTypeModel>(GoToItemsMethod);
            _unit = App.ServiceProvider.GetService(typeof(IV2BusinessUnit)) as IV2BusinessUnit;
            List<ServiceTypeModel> serviceTypeModels =Task.Run(async()=>await _unit.ServiceTypes.GetDepartmnetServiceTypes(departmentid)).Result;
            serviceTypeModels.ForEach(x => ServiceTypes.Add(x));
        }

        private void GoToItemsMethod(ServiceTypeModel obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.Online.ItemsView(obj.Id));
        }
    }
}
