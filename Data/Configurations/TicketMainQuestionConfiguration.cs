using Data.Entities.CustomerService.Ticket;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class TicketMainQuestionConfiguration : IEntityTypeConfiguration<TicketMainQuestion>
    {
        public void Configure(EntityTypeBuilder<TicketMainQuestion> builder)
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
