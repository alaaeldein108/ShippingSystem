using Data.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class QuotationConfiguartion : IEntityTypeConfiguration<Quotation>
    {
        public void Configure(EntityTypeBuilder<Quotation> builder)
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
