using Data.Entities.CustomerService.Abnormal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ReplyImagesConfiguration : IEntityTypeConfiguration<AbnormalReplyImages>
    {
        public void Configure(EntityTypeBuilder<AbnormalReplyImages> builder)
        {
            builder.HasKey(x => new
            {
                x.ReplyId,
                x.PictureUrl
            });
        }
    }
}
