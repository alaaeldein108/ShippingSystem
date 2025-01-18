using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class OrderScanConfiguration : IEntityTypeConfiguration<OrderScan>
    {
        public void Configure(EntityTypeBuilder<OrderScan> builder)
        {
            builder.HasKey(x => new
            {
                x.OrderNumber,
                x.ScanId
            });


        }
    }
}
