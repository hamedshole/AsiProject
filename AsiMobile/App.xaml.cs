using Asi.Application.Interface;
using Asi.Client;
using Asi.Mobile.LocalData;
using Asi.Model;
using AsiMobile.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;


[assembly: ExportFont("UIFontIcons.ttf", Alias = "FontIcons")]
[assembly: ExportFont("Montserrat-Bold.ttf", Alias = "Montserrat-Bold")]
[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat-Medium")]
[assembly: ExportFont("Montserrat-Regular.ttf", Alias = "Montserrat-Regular")]
[assembly: ExportFont("Montserrat-SemiBold.ttf", Alias = "Montserrat-SemiBold")]
[assembly: ExportFont("UIFontIcons.ttf", Alias = "FontIcons")]
namespace AsiMobile
{
    public partial class App : Application
    {
        public static int ItemId { get; set; }
        public static int DepartmentId { get; set; }
        public static int ServiceTypeId { get; set; }
        public static int CertificateTypeId { get; set; }
        public static IServiceProvider ServiceProvider { get; set; }
        public static UserModel LoggedUser { get; set; }
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjM3OEAzMTM5MmUzMTJlMzBVeS82aFZBTTBzSG56NU1iekJscW9VN0s1UGJMcHBMRlFYMGduOUgxaUFvPQ==");
            ServiceCollection services = new ServiceCollection();
            services.RegisterV2ApiClient();
            services.RegisterLocalData();
            ServiceProvider = services.BuildServiceProvider();
            InitializeComponent();
            IApplicationBusinessUnit applicationUnit = ServiceProvider.GetService(typeof(IApplicationBusinessUnit)) as IApplicationBusinessUnit;
           // int d = Task.Run(async () => await applicationUnit.Departments.GetAll()).Result.Count;
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {
        }

    }
}
