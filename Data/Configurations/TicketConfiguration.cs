using Data.Entities.CustomerService.Ticket;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
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
