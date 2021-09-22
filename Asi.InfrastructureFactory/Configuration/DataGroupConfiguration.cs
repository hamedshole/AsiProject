using Asi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asi.Infrastructure.Configuration
{
    public class DataGroupConfiguration : IEntityTypeConfiguration<FormDataGroup>
    {
        public void Configure(EntityTypeBuilder<FormDataGroup> builder)
        {
            //builder.HasOne(x => x.SavedFormData)
            //            .WithMany()
            //            .HasForeignKey(x => x.SavedFormDataId)
            //            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
