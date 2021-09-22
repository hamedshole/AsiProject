using Asi.Application.Interface;
using Asi.Client.V2.Interfaces;
using Asi.Model;
using AsiMobile.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AsiMobile.ViewModels.Online
{
    public class ItemsViewModel
    {
        private IV2BusinessUnit _unit;
        private IApplicationBusinessUnit _applicationUnit;
        public Command<ItemModel> SaveItem { get;private set; }
        public Command<ItemModel> SendCertificate { get; private set; }
        public ObservableCollection<ItemModel> Items{ get; set; }
        public ItemsViewModel(int serviceTypeId)
        {
            App.ServiceTypeId = serviceTypeId;
            Items = new ObservableCollection<ItemModel>();
            _applicationUnit = App.ServiceProvider.GetService(typeof(IApplicationBusinessUnit)) as IApplicationBusinessUnit;
            SaveItem = new Command<ItemModel>(SaveItemMethod);
            SendCertificate = new Command<ItemModel>(SendCertificateMethod);
            _unit = App.ServiceProvider.GetService(typeof(IV2BusinessUnit)) as IV2BusinessUnit;
            List<ItemModel> items =Task.Run(async()=>await _unit.Items.GetServieTypeItems(serviceTypeId)).Result;
            items.ForEach(x => Items.Add(x));
        }

        private void SendCertificateMethod(ItemModel obj)
        {
            App.ItemId = obj.Id;
            App.Current.MainPage.Navigation.PushAsync(new CertificateControlListView(obj.Id));
        }

        private async void SaveItemMethod(ItemModel obj)
        {
            
            List<FormTemplateModel> formTemplateModels = _unit.Form.GetFormTemplate(obj.Id);
            obj.FormTemplates = formTemplateModels;
           await _applicationUnit.Items.Create(obj);
        }
    }
}
