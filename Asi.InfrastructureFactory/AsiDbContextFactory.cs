using Asi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace Asi.Infrastructure
{
    public class AsiDbContextFactory : IDesignTimeDbContextFactory<AsiDbContext>
    {


        public AsiDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AsiDbContext>();
            optionsBuilder.UseSqlServer(@"Server = .; Database = AsiDb; Trusted_Connection = True;", b => b.MigrationsAssembly("Asi.Infrastructure.Factory"));

           // optionsBuilder.UseSqlServer(@"Server = (LocalDB)\MSSQLLocalDB; Integrated Security = true; Database=dbname", b => b.MigrationsAssembly("Asi.Infrastructure"));
            return new AsiDbContext(optionsBuilder.Options);
        }


       
    }
}
