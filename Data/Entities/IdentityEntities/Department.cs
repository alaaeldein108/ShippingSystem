using Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.IdentityEntities
{
    public class Department:BaseEntity
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public LevelTypeEnum LevelType { get; set; }
    }
}
