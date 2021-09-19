using Asi.Client.V2.Interfaces;
using Asi.Model;
using AsiMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace AsiMobile.ViewModels
{
   public class SendCertificateViewModel
    {
        private int _itemId;
        public Command AddForm { get; private set; }
        private IV2BusinessUnit _unit;
        public ObservableCollection<CertificateControlModel> CertificateControls { get; set; }
        public SendCertificateViewModel(int itemId)
        {
            CertificateControls = new ObservableCollection<CertificateControlModel>();
            _itemId = itemId;
            AddForm = new Command(AddFormMethod);
            _unit = App.ServiceProvider.GetService(typeof(IV2BusinessUnit)) as IV2BusinessUnit;
            
        }

        private void AddFormMethod(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new ItemFormsView(this, _itemId));
        }
    }
}
