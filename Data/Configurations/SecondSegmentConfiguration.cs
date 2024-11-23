using Data.Entities.Operation.Sorting;
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
    public class SecondSegmentConfiguration :IEntityTypeConfiguration<SecondSegment>
    {
        public void Configure(EntityTypeBuilder<SecondSegment> builder)
        {
            builder.HasOne(ss => ss.Branch)
                    .WithMany()
                    .HasForeignKey(ss => ss.BranchCode)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ss => ss.FirstSegment)
                .WithMany()
                .HasForeignKey(ss => ss.FirstSegmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
