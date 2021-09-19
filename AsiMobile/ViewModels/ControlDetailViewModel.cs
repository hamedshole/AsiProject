using Asi.Application.Interface;
using Asi.Model;
using AsiMobile.ViewModel;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;

namespace AsiMobile.ViewModels
{
    public class ControlDetailViewModel
    {
        public Command SendCertificateControl { get; private set; }
        private FormGroupsViewModel FormGroupsViewModel;
        public ObservableCollection<LinkModel> Links{ get; set; }
        private List<string> images = new List<string>();
        private IApplicationBusinessUnit _unit;
        public string LinkName { get; set; }
        public string LinkPhoneNumber { get; set; }
        public Command AddImage { get; private set; }
        private SignaturePad.Forms.SignaturePadView SignaturePadView;
        private StackLayout gallery;
        int count = 0;
        public ControlDetailViewModel(StackLayout gallery,SignaturePad.Forms.SignaturePadView signaturePad,FormGroupsViewModel formGroupsView)
        {
            this.SignaturePadView = signaturePad;
            SendCertificateControl = new Command(SendCertificateControlMethod);
            this.FormGroupsViewModel = formGroupsView;
            _unit = App.ServiceProvider.GetService(typeof(IApplicationBusinessUnit)) as IApplicationBusinessUnit;
            Links = new ObservableCollection<LinkModel>();
           // List<LinkModel> linkModels = Task.Run(async () => await _unit.Links.GetAll(0)).Result;
            //linkModels.ForEach(x => Links.Add(x));
            AddImage = new Command(AddImageMethod);
            this.gallery = gallery;
        }

        private async void SendCertificateControlMethod(object obj)
        {
            RequestCertificateControlModel requestCertificateControlModel = new RequestCertificateControlModel();
            requestCertificateControlModel.MainControllerId = App.LoggedUser.Id;
            requestCertificateControlModel.Time = DateTime.Now;
            requestCertificateControlModel.ControlTime = 1;
            requestCertificateControlModel.ItemImage = images;
            requestCertificateControlModel.Link = new Asi.Model.ValueObjects.ControlLink { Fullname = LinkName, PhoneNumber = LinkPhoneNumber };
       var s =await SignaturePadView.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png,true,true);
            using (var memoryStream = new MemoryStream())
            {
                byte[] bytes;
                s.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
                requestCertificateControlModel.Link.Signiture=Convert.ToBase64String(bytes);
            }
            this.FormGroupsViewModel.SubmitCertificateControl(requestCertificateControlModel);
        }

        private async void AddImageMethod(object obj)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                //await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Test",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Rear
            });
            var s = file.GetStream();
            using (var memoryStream = new MemoryStream())
            {
                byte[] bytes;
                s.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
                this.images.Add(Convert.ToBase64String(bytes));
            }
            (gallery.Children[count] as Image).Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                count++;

                return stream;
            });

            if (file == null)
                return;
        }
    }
}
