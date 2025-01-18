using Data.Entities.Operation.COD_FOD_Adjustment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CODFODAdjustmentAppConfiguration : IEntityTypeConfiguration<CODFODAdjustmentApp>
    {
        public void Configure(EntityTypeBuilder<CODFODAdjustmentApp> builder)
        {
            builder.HasOne(b => b.Register)
                  .WithMany()
                  .HasForeignKey(b => b.RegisterId)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.Auditor)
                    .WithMany()
                    .HasForeignKey(b => b.AuditorId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
