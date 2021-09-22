using Asi.Domain.Entities;
using Asi.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Asi.Infrastructure.Data
{

    //  public class AsiDbContext : IdentityDbContext<User,UserRole,int,IdentityUserClaim<int>,IdentityUserRole<int>,IdentityUserLogin<int>,IdentityRoleClaim<int>,IdentityUserToken<int>>, IAsiDbContext
    public class AsiDbContext : DbContext, IAsiDbContext

    {
        public DbSet<SavedFormData> SavedFormDatas { get; set; }
        public DbSet<FormTemplateRowMissMatchWord> TemplateRowMissMatchWords { get; set; }
        public DbSet<FormTemplateQuestionHeader> QuestionHeaders { get; set; }
        public DbSet<FormTemplateRow> FormTemplateRows { get; set; }
        public DbSet<FormTemplateGroup> FormTemplateGroups { get; set; }
        public DbSet<FormTemplate> FormTemplates { get; set; }
        public DbSet<FormTemplateAnswerColumn> AnswerColumns { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<UserDepartment> UserDepartments { get; set; }
        public DbSet<UserItems> UserItems { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CertificateControl> CertificateControls { get; set; }
        public DbSet<FormDataGroup> DataGroups { get; set; }
        public DbSet<FormDataRow> FormDataRows { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CertificateType> CertificateTypes { get; set; }

        public AsiDbContext(DbContextOptions<AsiDbContext> options) : base(options)
        {
          
            //if (!(this.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
              

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AsiDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        DbSet<TEntity> IAsiDbContext.Set<TEntity>()
        {
            return this.Set<TEntity>();
        }

        async Task<int> IAsiDbContext.SaveChangesAsync()
        {
            return await this.SaveChangesAsync();
        }






    }
}
