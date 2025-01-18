using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CourierOrderConfiguration : IEntityTypeConfiguration<CourierOrderScheduling>
    {
        public void Configure(EntityTypeBuilder<CourierOrderScheduling> builder)
        {
            builder.HasKey(x => new
            {
                x.OrderNumber,
                x.CourierId
            });
        }
    }
}
