using Data.Entities.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class RecieverAddBookConfiguration : IEntityTypeConfiguration<ReceiverAddressBook>
    {
        public void Configure(EntityTypeBuilder<ReceiverAddressBook> builder)
        {
            builder.HasOne(ra => ra.Client)
                    .WithMany(c => c.ReceiverAddresses) // assuming a navigation property exists
                    .HasForeignKey(ra => ra.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(ra => ra.Area)
                    .WithMany() // Assuming no navigation property
                    .HasForeignKey(ra => ra.AreaId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
