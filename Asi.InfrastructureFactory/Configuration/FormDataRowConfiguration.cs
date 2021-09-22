using Asi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asi.Infrastructure.Configuration
{
    public class FormDataRowConfiguration : IEntityTypeConfiguration<FormDataRow>
    {
        public void Configure(EntityTypeBuilder<FormDataRow> builder)
        {
            builder.HasOne(x => x.Template)
                     .WithMany()
                     .HasForeignKey(x => x.TemplateId)
                     .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
