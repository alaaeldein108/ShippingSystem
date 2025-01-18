using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.TotalFees)
                       .HasComputedColumnSql("[DeliveryFees] + [AdditionalFees] + [ChangeAddFees]");

            builder.Property(e => e.VolumeWeight)
                        .HasComputedColumnSql("(([Length] * [Width] * [Height]) / 5000)", stored: true);

            builder.HasOne(e => e.RecieverAddress)
             .WithMany()
             .HasForeignKey(e => e.RecieverAddressId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.SenderAddress)
                .WithMany()
                .HasForeignKey(e => e.SenderAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.ProductType)
                   .WithMany()
                   .HasForeignKey(o => o.ProductTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.WaybillNumber).IsUnique();

            builder.HasOne(b => b.PickupCourier)
                  .WithMany()
                  .HasForeignKey(b => b.PickupCourierId)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.SigningCourier)
                    .WithMany()
                    .HasForeignKey(b => b.SigningCourierId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
