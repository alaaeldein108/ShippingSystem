﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.CustomerService.Abnormal
{
    public class AbnormalSubReason
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public AbnormalMainReason MainReason { get; set; }
        [ForeignKey("MainReason")]
        public int MainReasonId { get; set; }
    }
}
