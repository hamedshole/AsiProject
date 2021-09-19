using Asi.Client.V2.Interfaces;
using Asi.Model;
using AsiMobile.View;
using AsiMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AsiMobile.ViewModels
{
   public class ItemFormsViewModel
    {
        private IV2BusinessUnit _unit;
        private SendCertificateViewModel _sendCertificateViewModel;
        public Command<FormDataModel> SelectForm { get; private set; }
        public ObservableCollection<FormDataModel> FormDatas { get; set; }
        public ItemFormsViewModel(SendCertificateViewModel sendCertificateViewModel,int itemId)
        {
            FormDatas = new ObservableCollection<FormDataModel>();
            this._sendCertificateViewModel = sendCertificateViewModel;
            SelectForm = new Command<FormDataModel>(SelectFormCommand);
            _unit = App.ServiceProvider.GetService(typeof(IV2BusinessUnit)) as IV2BusinessUnit;
            List<FormDataModel> formDataModels = _unit.Form.GetMobileForm(itemId);
            formDataModels.ForEach(x => FormDatas.Add(x));
        }

        private void SelectFormCommand(FormDataModel obj)
        {
            //App.Current.MainPage.Navigation.PushAsync(new ControlGroupsPage(obj,_sendCertificateViewModel));
        }
    }
}
