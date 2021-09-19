using Asi.Application.Interface;
using Asi.Application.Util;
using Asi.Business;
using Asi.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Asi.Application
{
    public static class DependencyInjection
    {
        public static void RegisterSqlServerBusiness(this IServiceCollection services, string connectionstring)
        {
            services.RegisterDbContext(connectionstring);
            services.RegisterDatabaseBusiness();
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddSingleton<IApplicationBusinessUnit, ApplicationBusinessUnit>();
        }
        //public static void RegisterSqliteBusiness(this IServiceCollection services,string path)
        //{
        //    services.RegisterSqliteDbContext(path);
        //    services.RegisterApplication();
        //    services.AddAutoMapper(typeof(MapperProfile));
        //    services.AddSingleton<IApplicationBusinessUnit, ApplicationBusinessUnit>();
        //}
    }
}
