using AsiMobile.ViewModels.Offline;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsiMobile.Views.Offline
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LinksView : ContentPage
    {
        public LinksView()
        {
            InitializeComponent();
            this.BindingContext = new LinkViewModel();
        }
    }
}