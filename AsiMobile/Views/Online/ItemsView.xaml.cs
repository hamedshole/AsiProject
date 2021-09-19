using AsiMobile.ViewModels.Online;
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
    public partial class ItemsView : ContentPage
    {
        public ItemsView(int serviceTypeId)
        {
            InitializeComponent();
            this.BindingContext = new ItemsViewModel(serviceTypeId);
        }
    }
}