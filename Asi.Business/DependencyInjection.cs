using Asi.Domain.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Asi.Business
{
    public static  class DependencyInjection
    {
        public static void RegisterDatabaseBusiness(this IServiceCollection services)
        {
            services.AddSingleton<IDbBusinessUnit,BusinessUnit>();
        }
    }
}
