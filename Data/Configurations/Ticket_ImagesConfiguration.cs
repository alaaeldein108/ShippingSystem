﻿using Data.Entities.CustomerService.Abnormal;
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
    public class Ticket_ImagesConfiguration: IEntityTypeConfiguration<TicketReplyImages>
    {
        public void Configure(EntityTypeBuilder<TicketReplyImages> builder)
        {
            builder.HasKey(x => new
            {
                x.TicketReplyId,
                x.PictureUrl
            });
        }
    }
}
