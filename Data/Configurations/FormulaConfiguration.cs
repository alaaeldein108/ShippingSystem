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
    public class FormulaConfiguration : IEntityTypeConfiguration<Formula>
    {
        public void Configure(EntityTypeBuilder<Formula> builder)
        {
            builder.HasOne(f => f.QuotationZone)
               .WithMany(qz => qz.Formulas)
               .HasForeignKey(f => new { f.ZoneId, f.QuotationId })
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
