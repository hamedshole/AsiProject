using Asi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asi.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           
            builder.HasOne(x => x.Role)
                        .WithMany()
                        .HasForeignKey(x => x.RoleId)
                        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
