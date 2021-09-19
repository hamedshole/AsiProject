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
    public partial class ServiceTypesView : ContentPage
    {
        public ServiceTypesView(int departmentId)
        {
            InitializeComponent();
            this.BindingContext = new ServiceTypeViewModel(departmentId);
        }
    }
}