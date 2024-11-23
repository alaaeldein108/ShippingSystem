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
    public class ClientQuotationConfiguration : IEntityTypeConfiguration<ClientQuotation>
    {
        public void Configure(EntityTypeBuilder<ClientQuotation> builder)
        {
            builder.HasKey(x => new
            {
                x.QuotationId,
                x.ClientCode
            });
        }
    }
}
