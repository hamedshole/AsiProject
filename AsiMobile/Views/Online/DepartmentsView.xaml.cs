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
    public partial class DepartmentsView : ContentPage
    {
        public DepartmentsView()
        {
            InitializeComponent();
            this.BindingContext = new DepartmentViewModel();
        }
    }
}