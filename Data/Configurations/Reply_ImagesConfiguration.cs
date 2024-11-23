using Data.Entities.CustomerService.Abnormal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class Reply_ImagesConfiguration : IEntityTypeConfiguration<AbnormalReplyImages>
    {
        public void Configure(EntityTypeBuilder<AbnormalReplyImages> builder)
        {
            builder.HasKey(x => new
            {
                x.ReplyNumber,
                x.PictureUrl
            });
        }
    }
}
