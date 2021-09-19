using Asi.Domain.Interface;
using Asi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Asi.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterDbContext(this IServiceCollection services, string connectionstring)
        {
            DbContextOptionsBuilder<AsiDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<AsiDbContext>().UseSqlServer(connectionstring, x => x.MigrationsAssembly("Asi.Infrastructure"));
            
            services.AddSingleton<IAsiDbContext, AsiDbContext>(x => new AsiDbContext(dbContextOptionsBuilder.Options));
        }
        //public static void RegisterSqliteDbContext(this IServiceCollection services,string path)
        //{
            
        //    string dbPath = Path.Combine(path, "asidb.db3");
        //    DbContextOptionsBuilder<AsiDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<AsiDbContext>().UseSqlite($"Filename={dbPath}", x=>x.MigrationsAssembly("Asi.Infrastructure"));
        //    services.AddSingleton<IAsiDbContext, AsiDbContext>(x => new AsiDbContext(dbContextOptionsBuilder.Options));
        //}


    }
   
}
