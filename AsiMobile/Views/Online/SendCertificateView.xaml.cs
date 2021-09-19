using AsiMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsiMobile.Views.Online
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendCertificateView : ContentPage
    {
        public SendCertificateView(int itemId)
        {
            InitializeComponent();
            this.BindingContext = new SendCertificateViewModel(itemId);
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {

        }

        private void PreviousButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}