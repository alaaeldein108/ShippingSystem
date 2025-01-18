using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CourierOrderSchudlingConfiguration : IEntityTypeConfiguration<CourierOrderScheduling>
    {
        public void Configure(EntityTypeBuilder<CourierOrderScheduling> builder)
        {
            builder.HasOne(cos => cos.Courier)
                .WithMany(appUser => appUser.CourierOrders)
                .HasForeignKey(cos => cos.CourierId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cos => cos.Assigner)
                    .WithMany()
                    .HasForeignKey(cos => cos.AssignerId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
