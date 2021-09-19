using Asi.Client.Util;
using Asi.Client.Util.Interfaces;
using Asi.Client.V1;
using Asi.Client.V1.Interfaces;
using Asi.Client.V2;
using Asi.Client.V2.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Asi.Client
{
    public static  class DependencyInjection
    {
        public static void RegisterV2ApiClient(this IServiceCollection services)
        {
            
            services.AddScoped<ICustomHttpClient, CustomHttpClient>();
            services.AddScoped<IV2BusinessUnit, V2BusinessUnit>();
        }
        public static void RegisterV1ApiClient(this IServiceCollection services)
        {

            services.AddScoped<ICustomHttpClient, CustomHttpClient>();
            services.AddScoped<IV1BusinessUnit, V1BusinessUnit>();
        }
    }
}
