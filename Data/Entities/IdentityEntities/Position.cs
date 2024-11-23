using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.IdentityEntities
{
    public class Position:BaseEntity
    {
        [Key]
        public string Code { get; set; }
        public string Title { get; set; }
        public Department Department { get; set; }
        [ForeignKey("Department")]
        public string DepartmentCode { get; set; }

    }
}
