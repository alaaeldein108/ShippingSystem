using Data.Entities.Finance;
using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ZoneConfiguration : IEntityTypeConfiguration<Zone>
    {
        public void Configure(EntityTypeBuilder<Zone> builder)
        {

            builder.HasOne(e => e.AffailiatedBranch)
              .WithMany()
              .HasForeignKey(e => e.AffailiatedBranchCode)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
