using Asi.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using Asi.Application;

namespace AsiApp
{
    static class Program
    {
        public static Dashboard Dashboard { get; set; }
        public static IServiceProvider ServiceProvider { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigureServices();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Dashboard = new Dashboard();
            Application.Run(Dashboard);
        }
        static void ConfigureServices()
        {
          
            IServiceCollection services = new ServiceCollection();
            services.RegisterV1ApiClient();
            services.RegisterSqlServerBusiness(@"Server=(LocalDB)\MSSQLLocalDB;Integrated Security=true;Database=dbname");
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
