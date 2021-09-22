using Asi.Mobile.LocalData.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Asi.Mobile.LocalData
{
    public static class DependencyInjection
    {
        public static void RegisterLocalData(this IServiceCollection services)
        {
            services.AddScoped<ILocalData, LocalData>();
        }
    }
}
