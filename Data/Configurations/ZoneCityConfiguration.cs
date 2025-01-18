using Data.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ZoneCityConfiguration : IEntityTypeConfiguration<ZoneCity>
    {
        public void Configure(EntityTypeBuilder<ZoneCity> builder)
        {
            builder.HasKey(x => new
            {
                x.CityId,
                x.ZoneId,
            });
        }
    }
}
