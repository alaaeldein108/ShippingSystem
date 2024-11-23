using Data.Entities.Operation;
using Data.Entities.Operation.Return_ChangeAdd;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

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


            builder.HasOne(e => e.DeliveryBR)
                .WithMany()
                .HasForeignKey(e => e.DeliveryBRId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(e => e.SigningBR)
                .WithMany()
                .HasForeignKey(e => e.SigningBRId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.PickupBR)
                .WithMany()
                .HasForeignKey(e => e.PickupBRId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.LastUpdateBR)
            .WithMany()
            .HasForeignKey(e => e.LastUpdateBRId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Return_ChangeAdd_App)
            .WithOne(c=>c.Order)
            .HasForeignKey<Return_ChangeAdd_App>(e => e.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.ProductType)
                   .WithMany()
                   .HasForeignKey(o => o.ProductTypeCode)
                   .OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}
