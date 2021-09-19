using Asi.Client.V2.Interfaces;
using Asi.Model;
using AsiMobile.Views.Online;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace AsiMobile.ViewModels.Online
{
   public class DepartmentViewModel
    {
        IV2BusinessUnit _unit { get; set; }
        public ObservableCollection<DepartmentModel> Departments { get; set; }
        public Command<DepartmentModel> GoToServiceTypes { get; private set; }
        public DepartmentViewModel()
        {
            Departments = new ObservableCollection<DepartmentModel>();
            GoToServiceTypes = new Command<DepartmentModel>(GoToServiceTypeMethod);
            _unit = App.ServiceProvider.GetService(typeof(IV2BusinessUnit)) as IV2BusinessUnit;
            List<DepartmentModel> departments = _unit.Departments.GetAll(0);
            departments.ForEach(x => Departments.Add(x));
        }

        private void GoToServiceTypeMethod(DepartmentModel obj)
        {
            App.DepartmentId = obj.Id;
            App.Current.MainPage.Navigation.PushAsync(new ServiceTypesView(obj.Id));
        }
    }
}
