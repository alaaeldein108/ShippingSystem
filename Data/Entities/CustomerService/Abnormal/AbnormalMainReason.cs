using Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.CustomerService.Abnormal
{
    public class AbnormalMainReason
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public StatusEnum Status { get; set; }
    }
}
