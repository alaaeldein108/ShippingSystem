using Data.Entities.Operation;
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
    public class Order_ScanConfiguration : IEntityTypeConfiguration<Order_Scan>
    {
        public void Configure(EntityTypeBuilder<Order_Scan> builder)
        {
            builder.HasKey(x =>new
            {
                x.OrderNumber,x.ScanCode
            });
            builder.HasOne(o => o.BranchScan)
           .WithMany()
           .HasForeignKey(o => o.BranchScanId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.NextBranch)
                .WithMany()
                .HasForeignKey(o => o.NextBranchId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
