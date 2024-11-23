using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class BranchLevelConfiguration:IEntityTypeConfiguration<BranchLevel>
    {
        public void Configure(EntityTypeBuilder<BranchLevel> builder)
        {

        }
    }
}
