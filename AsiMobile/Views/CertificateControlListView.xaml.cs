using Asi.Shared.Model;
using AsiMobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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