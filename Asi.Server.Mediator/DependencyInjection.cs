using Asi.Application;
using Asi.Server.Mediator.Repositories.Authentication.Login;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AsiServer.Mediator
{
    public static class DependencyInjection
    {
        public static void RegisterAsiMediator(this IServiceCollection build, IConfiguration configuration)
        {
            build.RegisterSqlServerBusiness(configuration.GetConnectionString("AsiDb"));
            build.AddMediatR(typeof(LoginCommand).Assembly);
        }
        
    }
}
