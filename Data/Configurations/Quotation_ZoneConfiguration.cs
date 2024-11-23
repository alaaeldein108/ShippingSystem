using Data.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class Quotation_ZoneConfiguration : IEntityTypeConfiguration<Quotation_Zone>
    {
        public void Configure(EntityTypeBuilder<Quotation_Zone> builder)
        {
            builder.HasKey(x => new { x.ZoneId, x.QuotationId });
        }
    }
}
