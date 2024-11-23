using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Addresses
{
    public class Distinct
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
