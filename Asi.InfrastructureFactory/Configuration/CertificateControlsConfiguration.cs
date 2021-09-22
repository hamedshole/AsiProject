using Asi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asi.Infrastructure.Configuration
{
    public class CertificateControlsConfiguration : IEntityTypeConfiguration<CertificateControl>
    {
        public void Configure(EntityTypeBuilder<CertificateControl> builder)
        {
            builder.HasOne(x => x.ControlForm)
                       .WithMany()
                       .HasForeignKey(x => x.ControlFormId)
                       .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.BranchPerson)
                       .WithMany()
                       .HasForeignKey(x => x.BranchId)
                       .OnDelete(DeleteBehavior.NoAction); ;
            builder.HasOne(x => x.Agancy)
                      .WithMany()
                      .HasForeignKey(x => x.AgancyId)
                      .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.CertificateController)
                      .WithMany()
                      .HasForeignKey(x => x.CertificateControllerId)
                      .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.MainController)
                      .WithMany()
                      .HasForeignKey(x => x.MainControllerId)
                      .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.TechnicalManager)
                      .WithMany()
                      .HasForeignKey(x => x.TechnicalManagerId)
                      .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Marketing)
                     .WithMany()
                     .HasForeignKey(x => x.MarketingId)
                     .OnDelete(DeleteBehavior.NoAction);
            builder.OwnsOne(p => p.Location)
                            .Property(p => p.Longtitude).HasColumnName("Location_Longtitude");
            builder.OwnsOne(p => p.Location)
                            .Property(p => p.Latitude).HasColumnName("Location_Latitude");
            builder.OwnsOne(p => p.Link)
                            .Property(p => p.Fullname).HasColumnName("Link_Name");
            builder.OwnsOne(p => p.Link)
                            .Property(p => p.PhoneNumber).HasColumnName("Link_PhoneNumber");
            builder.OwnsOne(p => p.Link)
                            .Property(p => p.Signiture).HasColumnName("Link_Signiture");

        }
    }
}
