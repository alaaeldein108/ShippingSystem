using Data.Entities.CustomerService.Abnormal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class AbnormalConfiguration : IEntityTypeConfiguration<Abnormal>
    {
        public void Configure(EntityTypeBuilder<Abnormal> builder)
        {
            builder.HasOne(b => b.Register)
                   .WithMany()
                   .HasForeignKey(b => b.RegisterId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.ClosedPerson)
                    .WithMany()
                    .HasForeignKey(b => b.ClosedPersonId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
