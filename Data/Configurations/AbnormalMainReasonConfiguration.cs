using Data.Entities.CustomerService.Abnormal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class AbnormalMainReasonConfiguration : IEntityTypeConfiguration<AbnormalMainReason>
    {
        public void Configure(EntityTypeBuilder<AbnormalMainReason> builder)
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
