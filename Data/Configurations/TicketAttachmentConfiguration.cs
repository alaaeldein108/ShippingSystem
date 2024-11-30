using Data.Entities.CustomerService.Ticket;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class TicketAttachmentConfiguration : IEntityTypeConfiguration<TicketAttachements>
    {
        public void Configure(EntityTypeBuilder<TicketAttachements> builder)
        {
            builder.HasKey(x => new
            {
                x.TicketNumber,
                x.AttachmentURL
            });
        }
    }
}
