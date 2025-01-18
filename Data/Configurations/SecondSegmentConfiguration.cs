using Data.Entities.Operation.Sorting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class SecondSegmentConfiguration : IEntityTypeConfiguration<SecondSegment>
    {
        public void Configure(EntityTypeBuilder<SecondSegment> builder)
        {
            builder.HasOne(ss => ss.Branch)
                    .WithMany()
                    .HasForeignKey(ss => ss.BranchId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ss => ss.FirstSegment)
                .WithMany()
                .HasForeignKey(ss => ss.FirstSegmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Creator)
                  .WithMany()
                  .HasForeignKey(b => b.CreatorId)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.Updator)
                    .WithMany()
                    .HasForeignKey(b => b.UpdatorId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
