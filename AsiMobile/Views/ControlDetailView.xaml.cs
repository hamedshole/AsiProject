using Asi.Model;
using AsiMobile.ViewModel;
using AsiMobile.ViewModels;
using Syncfusion.SfAutoComplete.XForms;
using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsiMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlDetailView : ContentPage
    {

        int count = 0;
        List<string> images = new List<string>();
        public ControlDetailView(FormGroupsViewModel formGroupsViewModel)
        {
            InitializeComponent();

            this.BindingContext = new ControlDetailViewModel(gallery, signiturepad, formGroupsViewModel);


        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //if (!CrossMedia.Current.IsPickPhotoSupported)
            //{
            //    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
            //    return;
            //}
            //var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            //{
            //    Directory = "Test",
            //    SaveToAlbum = true,
            //    CompressionQuality = 75,
            //    CustomPhotoSize = 50,
            //    PhotoSize = PhotoSize.MaxWidthHeight,
            //    MaxWidthHeight = 2000,
            //    DefaultCamera = CameraDevice.Rear
            //});
            //var s = file.GetStream();
            //using (var memoryStream = new MemoryStream())
            //{
            //    byte[] bytes;
            //    s.CopyTo(memoryStream);
            //    bytes = memoryStream.ToArray();
            //    this.images.Add(Convert.ToBase64String(bytes));
            //}
            //(gallery.Children[count] as Image).Source =ImageSource.FromStream(() =>
            //{
            //     var stream = file.GetStream();               
            //    file.Dispose();
            //    count++;

            //    return stream;
            //});

            //if (file == null)
            //    return;

        }

       

        private void SfAutoComplete_Completed(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty((sender as SfAutoComplete).Text))
            {
                LinkModel linkModel = (((sender as SfAutoComplete).Parent as StackLayout).Parent.BindingContext as ControlDetailViewModel).Links.Where(x => x.Fullname.Contains((sender as SfAutoComplete).Text)).FirstOrDefault();
                if (linkModel != null)
                    phonetext.Text = linkModel.PhoneNumber;

            }
        }
    }
}