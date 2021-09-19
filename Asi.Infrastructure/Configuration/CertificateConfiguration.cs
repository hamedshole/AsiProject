using Asi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asi.Infrastructure.Configuration
{
    public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.Property(x => x.Accepted).HasDefaultValue(false);
           
          
            builder.Property(x => x.Rejected).HasDefaultValue(false);
            builder.Property(x => x.Accepted).HasDefaultValue(false);
            //builder.HasOne(x => x.Item)
            //          .WithMany()
            //          .HasForeignKey(x => x.ItemId)
            //          .OnDelete(DeleteBehavior.NoAction);
            //builder.HasOne(x => x.ServiceType)
            //           .WithMany()
            //           .HasForeignKey(x => x.ServiceTypeId)
            //           .OnDelete(DeleteBehavior.NoAction);
            //builder.HasOne(x => x.CertificateType)
            //           .WithMany()
            //           .HasForeignKey(x => x.CertificateTypeId)
            //           .OnDelete(DeleteBehavior.NoAction);
            //builder.HasOne(x => x.RefferenceForm)
            //            .WithMany()
            //            .HasForeignKey(x => x.RefferenceFormId)
            //            .OnDelete(DeleteBehavior.NoAction);
            builder.OwnsOne(p => p.Company)
                            .Property(p => p.Fullname).HasColumnName("Company_Name");
            builder.OwnsOne(p => p.Company)
                            .Property(p => p.PhoneNumber).HasColumnName("Company_PhoneNumber");
            builder.OwnsOne(p => p.Company)
                            .Property(p => p.Address).HasColumnName("Company_Address");
        }
    }
}
