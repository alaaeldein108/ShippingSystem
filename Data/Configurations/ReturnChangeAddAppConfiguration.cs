using Data.Entities.Operation.Return_ChangeAdd;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ReturnChangeAddAppConfiguration : IEntityTypeConfiguration<ReturnChangeAddApp>
    {
        public void Configure(EntityTypeBuilder<ReturnChangeAddApp> builder)
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
