using Data.Entities.Operation.Sorting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class FirstSegmentConfiguration : IEntityTypeConfiguration<FirstSegment>
    {
        public void Configure(EntityTypeBuilder<FirstSegment> builder)
        {
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
