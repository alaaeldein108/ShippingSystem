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
    public class Abnormal_ImagesConfiguration : IEntityTypeConfiguration<AbnormalImages>
    {
        public void Configure(EntityTypeBuilder<AbnormalImages> builder)
        {
            builder.HasKey(x => new
            {
                x.AbnormalNumber,x.PictureUrl
            });
        }
    }
}
