using Asi.Model;
using AsiMobile.ViewModel;
using Plugin.Media;
using Plugin.Media.Abstractions;
using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsiMobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlFormPage : ContentPage
    {
        // Image image;
        string _itemImage;
        private ControlFormViewModel FormViewModel;
        public ControlFormPage(List<RequestCertificateControlModel> formDatas)
        {
            InitializeComponent();
            this.BindingContext =FormViewModel= new ControlFormViewModel(formDatas);
        }
        public ControlFormPage(RequestCertificateModel controlFormSend)
        {
            InitializeComponent();
            SignaturePad.Forms.SignaturePadView signaturePad = this.FindByName<SignaturePadView>("signpanel");
            this.BindingContext = FormViewModel = new ControlFormViewModel(controlFormSend, signaturePad);


        }

      

        private async void PickAPhotoButton_OnClicked(object sender, System.EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
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
            Stream c = file.GetStream();
            using (var memoryStream = new MemoryStream())
            {
                byte[] bytes;
                c.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
                this.FormViewModel.SetImage(Convert.ToBase64String(bytes));
            }
            if (file == null)
                return;
            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                //using (var memoryStream = new MemoryStream())
                //{
                //    byte[] bytes;
                //    stream.CopyTo(memoryStream);
                //    bytes = memoryStream.ToArray();
                //    this.FormViewModel.SetImage(Convert.ToBase64String(bytes));
                //}
                return stream;
            });
           
            
            
        }
    }
}