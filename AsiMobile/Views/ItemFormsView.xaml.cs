using AsiMobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsiMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemFormsView : ContentPage
    {
        public ItemFormsView(SendCertificateViewModel sendCertificateViewModel,int itemId)
        {
            InitializeComponent();
            BindingContext = new ItemFormsViewModel(sendCertificateViewModel, itemId);

        }
    }
}