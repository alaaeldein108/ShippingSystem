using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {

            builder.HasOne(e => e.CustomerBR)
              .WithMany()
              .HasForeignKey(e => e.CustomerBRId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Creator)
                  .WithMany()
                  .HasForeignKey(b => b.CreatorId)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.Updator)
                    .WithMany()
                    .HasForeignKey(b => b.UpdatorId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.SalesPerson)
                  .WithMany()
                  .HasForeignKey(b => b.SalesPersonId)
                  .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
