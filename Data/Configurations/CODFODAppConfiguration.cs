using Data.Entities.Operation.COD_FOD_Adjustment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CODFODAppConfiguration : IEntityTypeConfiguration<CODFODAdjustmentApp>
    {
        public void Configure(EntityTypeBuilder<CODFODAdjustmentApp> builder)
        {


        }
    }
}
