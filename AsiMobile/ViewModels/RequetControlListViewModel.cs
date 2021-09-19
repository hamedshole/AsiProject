using Asi.Client.V2.Interfaces;
using Asi.Model;
using AsiMobile.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AsiMobile.ViewModel
{
    public class RequetControlListViewModel
    {
        public ObservableCollection<FormDataModel> ItemFormTemplates { get; set; }
        public ObservableCollection<RequestCertificateControlModel> Contols { get; set; }
        public Command<FormDataModel> NewForm { get; set; }
        public Command SendRequest { get; set; }
        private readonly IV2BusinessUnit _unit;

        public RequetControlListViewModel(int itemId)
        {
            SendRequest = new Command(SendRequestMethod);
            NewForm = new Command<FormDataModel>(NewFormMethod);
            ItemFormTemplates = new ObservableCollection<FormDataModel>();
            Contols = new ObservableCollection<RequestCertificateControlModel>();
            _unit = App.ServiceProvider.GetService(typeof(IV2BusinessUnit)) as IV2BusinessUnit;
           List<FormDataModel> formtemplates = _unit.Form.GetMobileForm(itemId);
            formtemplates.ForEach(x => this.ItemFormTemplates.Add(x));
        }

        private void SendRequestMethod(object obj)
        {
            List<RequestCertificateControlModel> formDatas = new List<RequestCertificateControlModel>();
            for (int i = 0; i < this.Contols.Count; i++)
            {
                formDatas.Add(this.Contols[i]);
            }
            App.Current.MainPage.Navigation.PushAsync(new ControlFormPage(formDatas));
        }

        public async void SubmitForm(RequestCertificateControlModel certificateControlModel)
        {
            Xamarin.Essentials.Location location = await Geolocation.GetLastKnownLocationAsync();
            certificateControlModel.Location = new Asi.Model.ValueObjects.ControlLocation(location.Longitude, location.Latitude);
          
            this.Contols.Add(certificateControlModel);
        }
        private async void NewFormMethod(FormDataModel obj)
        {
            
            await App.Current.MainPage.Navigation.PushAsync(new ControlGroupsPage(obj,this),true);
            
        }
    }
}
