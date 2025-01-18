using Data.Entities.CustomerService.Abnormal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class AbnormalImagesConfiguration : IEntityTypeConfiguration<AbnormalImages>
    {
        public void Configure(EntityTypeBuilder<AbnormalImages> builder)
        {
            builder.HasKey(x => new
            {
                x.AbnormalNumber,
                x.PictureUrl
            });
        }
    }
}
