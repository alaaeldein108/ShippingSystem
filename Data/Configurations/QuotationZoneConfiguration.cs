using Data.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class QuotationZoneConfiguration : IEntityTypeConfiguration<QuotationZone>
    {
        public void Configure(EntityTypeBuilder<QuotationZone> builder)
        {
            builder.HasKey(x => new { x.ZoneId, x.QuotationId });
        }
    }
}
