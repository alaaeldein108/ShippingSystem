using Data.Entities.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class SenderAddBookConfiguration : IEntityTypeConfiguration<SenderAddressBook>
    {
        public void Configure(EntityTypeBuilder<SenderAddressBook> builder)
        {
            builder.HasOne(ra => ra.Client)
                               .WithMany(c => c.SenderAddresses) 
                               .HasForeignKey(ra => ra.ClientId)
                               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ra => ra.Area)
                    .WithMany() 
                    .HasForeignKey(ra => ra.AreaId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
