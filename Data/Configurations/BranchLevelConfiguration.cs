using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class BranchLevelConfiguration : IEntityTypeConfiguration<BranchLevel>
    {
        public void Configure(EntityTypeBuilder<BranchLevel> builder)
        {
            builder.HasOne(b => b.AffiliatedAgency)
                   .WithMany()
                   .HasForeignKey(b => b.AffiliatedAgencyId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.AffiliatedHQ)
                    .WithMany()
                    .HasForeignKey(b => b.AffiliatedHQId)
                    .OnDelete(DeleteBehavior.NoAction);

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
