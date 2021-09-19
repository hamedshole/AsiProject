using Asi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace Asi.Domain.Interface
{
    public interface IAsiDbContext
    {

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
        DbSet<SavedFormData> SavedFormDatas { get; set; }
        DbSet<FormTemplateRowMissMatchWord> TemplateRowMissMatchWords { get; set; }
        DbSet<FormTemplateRow> FormTemplateRows { get; set; }
        DbSet<FormTemplateGroup> FormTemplateGroups { get; set; }
        DbSet<FormTemplate> FormTemplates { get; set; }
        DbSet<FormTemplateAnswerColumn> AnswerColumns { get; set; }
        DbSet<FormTemplateQuestionHeader> QuestionHeaders { get; set; }
        DbSet<Person> Persons { get; set; }
        DbSet<User> Users { get; set; }
        // DbSet<UserRole> UserRoles { get; set; }
        DbSet<ServiceType> ServiceTypes { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Province> Provinces { get; set; }
        DbSet<UserDepartment> UserDepartments { get; set; }
        DbSet<UserItems> UserItems { get; set; }
        DbSet<Certificate> Certificates { get; set; }
        DbSet<CertificateControl> CertificateControls { get; set; }
        DbSet<FormDataGroup> DataGroups { get; set; }
        DbSet<FormDataRow> FormDataRows { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<CertificateType> CertificateTypes { get; set; }
    }
}
