using AsiMobile.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsiMobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CertificateControlListView : ContentPage
    {
        public CertificateControlListView(int itemId)
        {
            InitializeComponent();
            this.BindingContext = new RequetControlListViewModel(itemId);
        }
      
    }
}