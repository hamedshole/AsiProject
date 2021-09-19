using Asi.Client.V2.Interfaces;
using Asi.Model;
using Client.Business.Util;
using SignaturePad.Forms;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AsiMobile.ViewModel
{
    public class ControlFormViewModel
    {
        private int itemId;
        private int departmentId;
        private string Image;
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyAddress { get; set; }
        public string LinkName { get; set; }
        public string LinkPhone { get; set; }
        public string ProvinceTitle { get; set; }

        public List<string> StandardComboItems { get; set; }
        public List<CertificateTypeModel> CertificateTypeModels;
        public List<string> CertificateComboItems { get; set; }
        public List<ProvinceModel> ProvinceModels;
        public List<string> ProvinceComboItems { get; set; }
        private readonly IV2BusinessUnit _unit;
        public RequestCertificateModel Certificate { get; set; }
        public Command GoToGroupsPage { get; set; }
        public Command SaveForm { get; set; }
        public Command FormSend { get; set; }
        public ControlFormViewModel()
        {

        }
        public ControlFormViewModel(List<RequestCertificateControlModel> formDatas)
        {
            App.CertificateTypeId = formDatas[0].ControlForm.CertificateTypeId;
           // this.departmentId = departmentid;
            _unit = App.ServiceProvider.Get<IV2BusinessUnit>();
            Certificate = new RequestCertificateModel();
            Certificate.FormDatas = formDatas;
          //  FormData.FormData = controlFormData;
            Certificate.ControlTime = 1;
            Certificate.MainControllerId = App.LoggedUser.Id;
            CertificateTypeModels = _unit.CertificateTypes.GetAll(0);
            CertificateComboItems = CertificateTypeModels.Select(x => x.Title).ToList();
            ProvinceModels = _unit.Provinces.GetAll(0);
            ProvinceComboItems = ProvinceModels.Select(x => x.Title).ToList();
            Certificate.ControlDate = System.DateTime.Now;
            GoToGroupsPage = new Command(GoToGroupPage);
            SaveForm = new Command(SaveFormMethod);
            FormSend = new Command(SendFormMethod);
        }

        

        public void SetImage(string stream)
        {
            this.Image = stream;
        }
        public ControlFormViewModel(RequestCertificateModel controlFormSend, SignaturePadView signaturePad)
        {
            
            this.Certificate = controlFormSend;
           // this.itemId = itemId;
            // this.departmentId = departmentid;
           _unit = App.ServiceProvider.Get<IV2BusinessUnit>();
           //FormData = new ControlFormSendModel();
         //   FormData.ServiceTypeId = controlFormSend;
         //   FormData.FormData = controlFormData;
          //  FormData.ControlTime = 1;
            Certificate.MainControllerId = App.LoggedUser.Id;
            CertificateTypeModels = _unit.CertificateTypes.GetAll(1, 20);
            CertificateComboItems = CertificateTypeModels.Select(x => x.Title).ToList();
            ProvinceModels = _unit.Provinces.GetAll(1, 20);
            ProvinceComboItems = ProvinceModels.Select(x => x.Title).ToList();
            Certificate.ControlDate = System.DateTime.Now;
            GoToGroupsPage = new Command(GoToGroupPage);
            SaveForm = new Command(SaveFormMethod);
            FormSend = new Command(SendFormMethodMissmatch);
        }
        private async void SendFormMethodMissmatch()
        {
           
          //  this.Certificate.ProvinenceId = this.ProvinceModels.Where(x => x.Title == this.Certificate.Provinence).Select(x => x.Id).FirstOrDefault();
            // this.FormData.ItemId = this.itemId;
            //_formRepository.SendForm(this.FormData);
            Location location = await Geolocation.GetLastKnownLocationAsync();
            byte[] bytes;
            //this.Certificate.Image = this.Image;
          //  this.Certificate.LocationLatitude = location.Latitude;
           // this.Certificate.LocationLongtitude = location.Longitude;
           // _unit.Certificates.SendRequest(this.Certificate);
        }
        private async void SendFormMethod()
        {
            this.Certificate.CertificateTypeId = App.CertificateTypeId;
            this.Certificate.MainControllerId = App.LoggedUser.Id;
            this.Certificate.ServiceTypeId = App.ServiceTypeId;
            this.Certificate.DepartmentId = App.DepartmentId;
            this.Certificate.ItemId = App.ItemId;
            this.Certificate.ProvinenceId = this.ProvinceModels.Where(x => x.Title == this.ProvinceTitle).Select(x => x.Id).FirstOrDefault();
            this.Certificate.Company = new Asi.Shared.Model.ValueObjects.Company { Address = this.CompanyAddress, Fullname = this.CompanyName, PhoneNumber = this.CompanyPhone };
            this.Certificate.Image = this.Image;
            //_formRepository.SendForm(this.FormData);
            _unit.Certificates.SendRequest(this.Certificate);
        }

        private void SaveFormMethod(object obj)
        {
            
        }

        private void GoToGroupPage(object obj)
        {
           // Application.Current.MainPage.Navigation.PushAsync(new ControlGroupsPage(FormData.FormData));
        }
    }
}
